namespace Entities.Concrete;

public class SavedItem:IEntity
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
}