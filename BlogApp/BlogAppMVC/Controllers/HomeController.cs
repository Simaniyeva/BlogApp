using BlogAppMVC;
using BlogAppMVC.Models;
namespace Neon.Controllers;

public class HomeController : Controller
{
    private readonly IBlogService _blogService;
    private readonly ITagService _tagService;
    private readonly IAccountService _accountService;

    public HomeController(IBlogService blogService, ITagService tagService, IAccountService accountService)
    {
        _blogService = blogService;
        _tagService = tagService;
        _accountService = accountService;
    }

    public async Task<IActionResult> Index()
    {
        IDataResult<List<BlogGetDto>> blogResult = await _blogService.GetAllAsync(false,Includes.BlogIncludes);
        IDataResult<List<TagGetDto>> tagResult = await _tagService.GetAllAsync(false,Includes.TagIncludes);
       HomeVM vm = new()
        {
            BlogsResult = blogResult,
            TagsResult=tagResult,
        };
        return View(vm);
    }




}