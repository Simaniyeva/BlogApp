namespace Entities.Concrete;

public class BlogImage:IEntity
{
    public int Id { get; set; }
    public string ImagePath { get; set; }
    public bool isDeleted { get; set; }
    public DateTime CreatedDate { get; set; }

    //Relations
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
