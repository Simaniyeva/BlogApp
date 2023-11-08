namespace Entities.DTOs.SavedItem;

public class SavedItemUpdateDto : IDto
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public string UserId { get; set; }
}
