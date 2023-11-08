namespace Entities.Concrete;

public class Blog:IEntity
{
    public Blog()
    {
        BlogImages=new List<BlogImage>();
        BlogTags = new List<BlogTag>();
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReadingTime { get; set; }
    public int ViewCount { get; set; }
    public bool isActive  { get; set; }
    public bool isDeleted { get; set; }
    public DateTime CreatedDate { get; set; }


    //Relations
    public List<BlogImage>BlogImages { get; set; }
    public List<BlogTag>BlogTags { get; set; }
    public List<SavedItem>SavedItems { get; set; }
    public List<Review>Reviews { get; set; }
  
}
