using Entities.Concrete;
using Entities.DTOs.BlogTag;
using Entities.DTOs.Review;
using Entities.DTOs.SavedItem;

namespace Entities.DTOs.Blog;

public class BlogGetDto:IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReadingTime { get; set; }
    public int ViewCount { get; set; }
    public bool isActive { get; set; }
    public bool isDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    //Relations
    public List<ReviewGetDto>Reviews { get; set; }
    public List<SavedItemGetDto>SavedItems { get; set; }
    public List<BlogImage>BlogImages { get; set; }
    public List<BlogTagGetDto>BlogTags { get; set; }


}
