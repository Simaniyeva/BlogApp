
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.Blog;

public class BlogPostDto:IDto
{
    public BlogPostDto()
    {
        TagIds = new List<int>();
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReadingTime { get; set; }
    public DateTime CreatedDate { get; set; }

    //Relations
    public List<IFormFile>formFiles { get; set; }

    public List<int>?TagIds { get; set; }

}
