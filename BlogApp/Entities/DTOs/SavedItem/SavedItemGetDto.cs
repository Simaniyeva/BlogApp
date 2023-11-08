using Entities.DTOs.Account;

namespace Entities.DTOs.SavedItem;

public class SavedItemGetDto:IDto
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public BlogGetDto Blog { get; set; }
    public UserGetDto User { get; set; }
}
