namespace Entities.DTOs.SavedItem;

public class SavedItemPostDto : IDto
{
    public int BlogId { get; set; }
    public string UserId { get; set; }
}