using Entities.DTOs.BlogTag;

namespace Entities.DTOs.Tag;

public class TagGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }
    //Relations
    public List<BlogTagGetDto>BlogTags { get; set; }
}
