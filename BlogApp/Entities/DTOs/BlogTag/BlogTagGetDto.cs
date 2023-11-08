

namespace Entities.DTOs.BlogTag;

public class BlogTagGetDto:IDto
{
    public int Id { get; set; }
    public BlogGetDto Blog { get; set; }
    public TagGetDto Tag { get; set; }
}
