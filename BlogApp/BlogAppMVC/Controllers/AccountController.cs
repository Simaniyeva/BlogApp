using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Utilities.ValidationRules.FluentValidation.Register;

namespace BlogAppMVC.Controllers;

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
    public async Task<IActionResult> Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if (!ModelState.IsValid)
            return View(registerDto);
        var result = await _accountService.Register(registerDto);
        if (!result)
        {
            return View(registerDto);
        }
        await _accountService.Register(registerDto);
        return RedirectToAction(nameof(Login));
    }


    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _accountService.Login(loginDto);
        if (!result)
        {
            return View(loginDto);
        }
        return RedirectToAction("Index","Home");
    }

    //[Authorize(Roles = "SuperAdmin,Admin,User")]
    public async Task<IActionResult> Logout()
    {
        await _accountService.SignOutAsync();
        return RedirectToAction("index","Home");
    }

    #endregion

    public async Task<IActionResult> Profile()
    {
        IDataResult<UserGetDto> result = await _accountService.GetUserByClaims(User, Includes.UserIncludes);
        return View(result);
    }

}
