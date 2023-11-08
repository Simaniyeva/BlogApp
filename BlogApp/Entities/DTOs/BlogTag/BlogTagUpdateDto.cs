

namespace Entities.DTOs.BlogTag;

public class BlogTagUpdateDto : IDto
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public int TagId { get; set; }
}
