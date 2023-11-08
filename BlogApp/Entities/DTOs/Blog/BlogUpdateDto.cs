using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.Blog;

public class BlogUpdateDto : IDto
{
    public BlogUpdateDto()
    {
        TagIds = new List<int>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReadingTime { get; set; }
    public DateTime CreatedDate { get; set; }
    //Relations
    public List<IFormFile> formFiles { get; set; }
    public List<int>? TagIds { get; set; }

}
