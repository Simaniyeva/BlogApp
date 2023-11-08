using IResult = BusinessLogicLayer.Utilities.Results.IResult;
namespace BlogAppMVC.Areas.Manage.Controllers;
[Area("Manage")]
[Authorize(Roles = "Admin,SuperAdmin")]
public class BlogController : Controller
{ private readonly IBlogService _blogService;
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;

    public BlogController(IBlogService blogService, IMapper mapper, ITagService tagService)
    {
        _blogService = blogService;
        _mapper = mapper;
        _tagService = tagService;
    }

    public async Task<IActionResult> Index()
    {
        IDataResult<List<BlogGetDto>> result = await _blogService.GetAllAsync(true,Includes.BlogIncludes);
        return View(result);
    }

    public async Task<IActionResult> Get(int id)
    {
        IDataResult<BlogGetDto> result = await _blogService.GetByIdAsync(id, Includes.BlogIncludes);
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await FillViewBags();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BlogPostDto dto)
    {
        if (!ModelState.IsValid)
        {
            await FillViewBags();
            return View(dto);
        }
        IResult result = await _blogService.CreateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        IDataResult<BlogGetDto> result = await _blogService.GetByIdAsync(id,"BlogImages","BlogTags.Tag");
        await FillViewBags();
        return View(_mapper.Map<BlogUpdateDto>(result.Data));
    }
    [HttpPost]
    public async Task<IActionResult> Update(BlogUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _blogService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        BlogGetDto result = (await _blogService.GetByIdAsync(id)).Data;
        if (result == null) { return Json(404); }
        await _blogService.SoftDeleteByIdAsync(id);
        return Json(200);
    }

    public async Task<IActionResult> Recover(int id)
    {
        BlogGetDto result = (await _blogService.GetByIdAsync(id)).Data;
        if (result == null) { return Json(404); }
        await _blogService.RecoverByIdAsync(id);
        return Json(200);
    }

    public async Task<IActionResult> HardDelete(int id)
    {
        BlogGetDto result = (await _blogService.GetByIdAsync(id)).Data;
        if (result == null) { return Json(404); }
        await _blogService.HardDeleteByIdAsync(id);
        return Json(200);
    }

    #region PrivateMethods
    private async Task FillViewBags()
    {
        IDataResult<List<TagGetDto>> tags = await _tagService.GetAllAsync(false);
        ViewBag.Tags = tags.Data.Select(t => new SelectListItem
        {
            Value=t.Id.ToString(),
            Text=t.Name
        });
    }

    #endregion

}
