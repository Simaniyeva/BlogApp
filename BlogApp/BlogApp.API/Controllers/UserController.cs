using BusinessLogicLayer.Services.Abstract;
using BusinessLogicLayer.Utilities.Results;
using Entities.DTOs.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDto>>> GetUsers([FromQuery] string? id)
        {
            if (id != null)
            {
                IDataResult<UserGetDto> result = await _accountService.GetUserById(id, Includes.UserIncludes);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return NotFound();
            }
            else
            {
                IDataResult<List<UserGetDto>> users = await _accountService.GetAllUser();
                if (users.Success)
                {
                    return Ok(users.Data);
                }
                return BadRequest(users.Message);
            }
        }
        [HttpPatch("{id}/evokeadmin")]
        public async Task<IActionResult> EvokeUserToAdmin(string id)
        {
            var getResult = await _accountService.GetUserById(id);
            if (!getResult.Success)
            {
                return NotFound();
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _accountService.EvokeUserToAdmin(getResult.Data);

            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPatch("{id}/revokeadmin")] 
        public async Task<IActionResult> RevokeUserFromAdmin(string id)
        {
            var getResult = await _accountService.GetUserById(id);
            if (!getResult.Success)
            {
                return NotFound();
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _accountService.RevokeFromAdmin(getResult.Data);

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
