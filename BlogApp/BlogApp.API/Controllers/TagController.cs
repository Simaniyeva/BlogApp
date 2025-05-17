using BusinessLogicLayer.Services.Abstract;
using BusinessLogicLayer.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Blog;
using Entities.DTOs.Tag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace BlogApp.API.Controllers
{
    [Route("tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagGetDto>>> GetTagById([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var tag = await _tagService.GetByIdAsync(id.Value);

                if (tag == null)
                {
                    return NotFound();
                }
                return Ok(tag);
            }
            else
            {
                var tags = await _tagService.GetAllAsync(false,Includes.TagIncludes);
                return Ok(tags);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(TagPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _tagService.CreateAsync(dto);

            if (result.Success)
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, TagUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dto.Id != id)
            {
                return BadRequest("ID mismatch: The ID in the route does not match the ID in the request body.");
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _tagService.UpdateAsync(dto);

            if (result.Success)
            {
                return NoContent();
            }
            else
            {
                if (result.Message.Contains("not found"))
                {
                    return NotFound();
                }
                return BadRequest(result.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);

            if (!tag.Success)
            {
                return NotFound();
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _tagService.SoftDeleteByIdAsync(id);

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
        public async Task<IActionResult> RecoverTag(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (!tag.Success)
            {
                return NotFound();
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _tagService.RecoverByIdAsync(id);

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
        public async Task<IActionResult> HardDeleteTag(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (!tag.Success)
            {
                return NotFound();
            }

            BusinessLogicLayer.Utilities.Results.IResult result = await _tagService.HardDeleteByIdAsync(id);

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
