using IResult = BusinessLogicLayer.Utilities.Results.IResult;
namespace BlogAppMVC.Areas.Manage.Controllers;
[Area("Manage")]
[Authorize(Roles = "Admin,SuperAdmin")]
public class TagController : Controller
{
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;

    public TagController(ITagService tagService, IMapper mapper)
    {
        _tagService = tagService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        IDataResult<List<TagGetDto>> result = await _tagService.GetAllAsync(true);
        return View(result);
    }

    public async Task<IActionResult> Get(int id)
    {
        IDataResult<TagGetDto> result = await _tagService.GetByIdAsync(id,Includes.TagIncludes);
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TagPostDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        IResult result = await _tagService.CreateAsync(dto);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        IDataResult<TagGetDto> result = await _tagService.GetByIdAsync(id);
        return View(_mapper.Map<TagUpdateDto>(result.Data));
    }
    [HttpPost]
    public async Task<IActionResult> Update(TagUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _tagService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        TagGetDto result = (await _tagService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _tagService.SoftDeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Recover(int id)
    {
        TagGetDto result = (await _tagService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _tagService.RecoverByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> HardDelete(int id)
    {
        TagGetDto result = (await _tagService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _tagService.HardDeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }

}
