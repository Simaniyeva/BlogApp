namespace Entities.Concrete;

public class Review : IEntity
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public Rating Rating { get; set; }
    public bool isDeleted { get; set; }
    public DateTime CreatedDate { get; set; }



    //Relations
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }

}

