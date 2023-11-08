using Entities.DTOs.Account;

namespace Entities.DTOs.Review;

public class ReviewGetDto:IDto
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public Rating Rating { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool isDeleted { get; set; }

    //Relations
    public UserGetDto User { get; set; }
    public BlogGetDto  Blog{ get; set; }
}
