namespace BlogAppMVC.Models;

public class HomeVM
{
    public IDataResult<List<BlogGetDto>>? BlogsResult { get; set; }
    public IDataResult<List<TagGetDto>>? TagsResult { get; set; }
    //public IDataResult<UserGetDto>? UserResult { get; set; }
}
