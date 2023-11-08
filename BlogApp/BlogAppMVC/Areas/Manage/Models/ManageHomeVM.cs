namespace BlogAppMVC.Areas.Manage.Models;

public class ManageHomeVM
{
    public List<UserGetDto>? UserResult { get; set; }
    public List<ReviewGetDto>? ReviewResult { get; set; }
    public List<SavedItemGetDto>? SavedItemResult { get; set; }

}
