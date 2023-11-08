
namespace Neon.Controllers;

public class TagController : Controller
{
    private readonly IBlogService _blogService;
    private readonly ITagService _tagService;

    public TagController(IBlogService blogService, ITagService tagService)
    {
        _blogService = blogService;
        _tagService = tagService;
    }

    public async Task<IActionResult> Index()
    {
        IDataResult<List<BlogGetDto>> blogResult = await _blogService.GetAllAsync(false, Includes.BlogIncludes);
        IDataResult<List<TagGetDto>> tagResult = await _tagService.GetAllAsync(false, Includes.TagIncludes);
        HomeVM vm = new()
        {
            BlogsResult = blogResult,
            TagsResult = tagResult
        };
        return View(vm);
    }
    public async Task<IActionResult> Get(int id)
    {
        IDataResult<TagGetDto> result = await _tagService.GetByIdAsync(id, Includes.TagIncludes);
        return View(result);
    }
}