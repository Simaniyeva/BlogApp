using BusinessLogicLayer.Services.Abstract;
using Entities.DTOs.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
            private readonly IBlogService _blogService;
            public BlogController(IBlogService blogService)
            {
                _blogService = blogService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<BlogGetDto>>> GetBlogById([FromQuery] int? id)
            {
                if (id.HasValue)
                {
                    var blog = await _blogService.GetByIdAsync(id.Value);

                    if (blog == null)
                    {
                        return NotFound();
                    }
                    return Ok(blog);
                }
                else
                {
                    var blogs = await _blogService.GetAllAsync(false, Includes.BlogIncludes);
                    return Ok(blogs);
                }
            }
            [HttpPost]
            public async Task<IActionResult> CreateBlog(BlogPostDto dto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                BusinessLogicLayer.Utilities.Results.IResult result = await _blogService.CreateAsync(dto);

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
            public async Task<IActionResult> UpdateBlog(int id, BlogUpdateDto dto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (dto.Id != id)
                {
                    return BadRequest("ID mismatch: The ID in the route does not match the ID in the request body.");
                }

                BusinessLogicLayer.Utilities.Results.IResult result = await _blogService.UpdateAsync(dto);

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
            public async Task<IActionResult> DeleteBlog(int id)
            {
                var blog = await _blogService.GetByIdAsync(id);

                if (!blog.Success)
                {
                    return NotFound();
                }

                BusinessLogicLayer.Utilities.Results.IResult result = await _blogService.SoftDeleteByIdAsync(id);

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
            public async Task<IActionResult> RecoverBlog(int id)
            {
                var Blog = await _blogService.GetByIdAsync(id);
                if (!Blog.Success)
                {
                    return NotFound();
                }

                BusinessLogicLayer.Utilities.Results.IResult result = await _blogService.RecoverByIdAsync(id);

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
            public async Task<IActionResult> HardDeleteBlog(int id)
            {
                var blog = await _blogService.GetByIdAsync(id);
                if (!blog.Success)
                {
                    return NotFound();
                }

                BusinessLogicLayer.Utilities.Results.IResult result = await _blogService.HardDeleteByIdAsync(id);

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
