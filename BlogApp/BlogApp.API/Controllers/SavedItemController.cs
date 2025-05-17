using BusinessLogicLayer.Services.Abstract;
using BusinessLogicLayer.Utilities.Results;
using Entities.DTOs.SavedItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("saveditem")]
    [ApiController]
    public class SavedItemController : ControllerBase
    {
        private readonly ISavedItemService _savedItemService;
        private readonly IAccountService _accountService;

        public SavedItemController(ISavedItemService savedItemService, IAccountService accountService)
        {
            _savedItemService = savedItemService;
            _accountService = accountService;
        }
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<SavedItemGetDto>>> GetSavedItemsByUser(string userId)
        {
            IDataResult<List<SavedItemGetDto>> result = await _savedItemService.GetAllByUserIdAsync(userId,Includes.BlogIncludes);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SavedItemGetDto>> AddToSavedItem(int blogId, [FromHeader(Name = "UserId")] string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserId header is required.");
            }
            SavedItemPostDto dto = new()
            {
                BlogId = blogId,
                UserId = userId
            };

            var result = await _savedItemService.CreateAsync(dto);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


        [HttpDelete("{id}")] 
        public async Task<IActionResult> RemoveFromSavedItem(int id, [FromHeader(Name = "UserId")] string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserId header is required.");
            }
            var result = await _savedItemService.HardDeleteByIdAsync(id);

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

