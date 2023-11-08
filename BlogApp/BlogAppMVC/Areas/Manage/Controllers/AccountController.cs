namespace BlogAppMVC.Areas.Manage.Controllers;

[Authorize(Roles = "SuperAdmin,Admin")]
[Area("Manage")]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private IMapper _mapper;
    private readonly ISavedItemService _savedItemService;
    private readonly IBlogService _blogService;

    public AccountController(IAccountService accountService, IMapper mapper, ISavedItemService savedItemService, IBlogService blogService)
    {
        _accountService = accountService;
        _mapper = mapper;
        _savedItemService = savedItemService;
        _blogService = blogService;
    }

    #region Auth

    [HttpGet]
    [Area("Manage")]

    public async Task<IActionResult> Login()
    {
        return View();
    }


    [HttpPost]
    [Area("Manage")]

    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _accountService.Login(loginDto);
        if (!result)
        {
            return View(loginDto);
        }
        return RedirectToAction("Index", "Home", new { area = "Manage" });
    }

    public async Task<IActionResult> Logout()
    {
        await _accountService.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    #endregion
    [Area("Manage")]

    public async Task<IActionResult> Profile()
    {
        return View();
    }

}


