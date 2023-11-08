using IResult = BusinessLogicLayer.Utilities.Results.IResult;
namespace BlogAppMVC.Areas.Manage.Controllers;
[Area("Manage")]
[Authorize(Roles = "Admin,SuperAdmin")]
public class RoleController : Controller
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public RoleController(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        IDataResult<List<RoleGetDto>> result = await _roleService.GetAllAsync();
        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        IDataResult<RoleGetDto> result = await _roleService.GetByIdAsync(id);
        return PartialView("_getRolePartial", result);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(RolePostDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        IResult result = await _roleService.CreateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(string id)
    {
        IDataResult<RoleGetDto> result = await _roleService.GetByIdAsync(id);
        return View(_mapper.Map<RoleUpdateDto>(result.Data));
    }
    [HttpPost]
    public async Task<IActionResult> Update(RoleUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        await _roleService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(string id)
    {
        RoleGetDto result = (await _roleService.GetByIdAsync(id)).Data;
        if (result == null) { return RedirectToAction(nameof(Index)); }
        await _roleService.HardDeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }

}
