using AutoMapper;
using BusinessLogicLayer.Services.Abstract;
using BusinessLogicLayer.Utilities.Results;
using Entities.DTOs.Role;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[Route("role")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public RoleController(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleGetDto>>> GetRoles([FromQuery] string? id)
    {
        if (id != null)
        {
            IDataResult<RoleGetDto> result = await _roleService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound();
        }
        else
        {
            IDataResult<List<RoleGetDto>> result = await _roleService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
    [HttpPost]
    public async Task<ActionResult<RoleGetDto>> CreateRole(RolePostDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        BusinessLogicLayer.Utilities.Results.IResult result = await _roleService.CreateAsync(dto);
        if (result.Success)
        {
            return Ok(dto);
        }
        return BadRequest(result.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(string id, RoleUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (dto.Id != id) //  Very important ID check.
        {
            return BadRequest("ID mismatch: The ID in the route does not match the ID in the request body.");
        }

        BusinessLogicLayer.Utilities.Results.IResult result = await _roleService.UpdateAsync(dto);
        if (result.Success)
        {
            return NoContent();
        }
        else if (result.Message.Contains("not found"))
        {
            return NotFound();
        }
        return BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(string id)
    {
        var getResult = await _roleService.GetByIdAsync(id);
        if (!getResult.Success)
        {
            return NotFound();
        }
        BusinessLogicLayer.Utilities.Results.IResult result = await _roleService.HardDeleteByIdAsync(id);
        if (result.Success)
        {
            return NoContent();
        }
        return BadRequest(result.Message);
    }
}

