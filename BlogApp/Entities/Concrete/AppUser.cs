
namespace Entities.Concrete;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Relations
    public List<Review>Reviews { get; set; }
    public List<SavedItem>SavedItems { get; set; }
}
