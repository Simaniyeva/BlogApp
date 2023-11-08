namespace Entities.Concrete;

public class Tag:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }
    public DateTime CreatedDate { get; set; }

    //Relations
    public List<BlogTag>BlogTags { get; set; }
}
