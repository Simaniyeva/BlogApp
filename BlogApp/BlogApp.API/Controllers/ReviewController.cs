using BusinessLogicLayer.Services.Abstract;
using BusinessLogicLayer.Utilities.Results;
using Entities.DTOs.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IAccountService _accountService;

        public ReviewController(IReviewService reviewService,IAccountService accountService)
        {
            _reviewService = reviewService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewGetDto>>> GetReviews([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                IDataResult<ReviewGetDto> result = await _reviewService.GetByIdAsync(id.Value, Includes.ReviewIncludes);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return NotFound();
            }
            else
            {
                IDataResult<List<ReviewGetDto>> result = await _reviewService.GetAllAsync(true, Includes.ReviewIncludes);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userResult = await _accountService.GetUserByClaims(HttpContext.User);
            if (!userResult.Success)
            {
                return Unauthorized();
            }
            dto.UserId = userResult.Data.Id;

            BusinessLogicLayer.Utilities.Results.IResult result = await _reviewService.CreateAsync(dto);

            if (result.Success)
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var getResult = await _reviewService.GetByIdAsync(id);
            if (!getResult.Success)
            {
                return NotFound();
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _reviewService.SoftDeleteByIdAsync(id);

            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPatch("{id}/recover")]
        public async Task<IActionResult> RecoverReview(int id)
        {
            var getResult = await _reviewService.GetByIdAsync(id);
            if (!getResult.Success)
            {
                return NotFound();
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _reviewService.RecoverByIdAsync(id);

            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("{id}/harddelete")]
        public async Task<IActionResult> HardDeleteReview(int id)
        {
            var getResult = await _reviewService.GetByIdAsync(id);
            if (!getResult.Success)
            {
                return NotFound();
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _reviewService.HardDeleteByIdAsync(id);

            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
