namespace BlogAppMVC.Areas.Manage.Controllers;
[Area("Manage")]
[Authorize(Roles = "Admin,SuperAdmin")]
public class HomeController : Controller
{
    private readonly IAccountService _accountService;
    private readonly IReviewService _reviewService; 
    private readonly ISavedItemService _savedItemService;

    public HomeController(IAccountService accountService, IReviewService reviewService, ISavedItemService savedItemService)
    {
        _accountService = accountService;
        _reviewService = reviewService;
        _savedItemService = savedItemService;
    }

    public async Task<IActionResult> Index()
    {
        IDataResult<List<UserGetDto>> userResult = await _accountService.GetAllUser(Includes.UserIncludes);
        IDataResult<List<ReviewGetDto>> reviewResult = await _reviewService.GetAllAsync(false,Includes.ReviewIncludes);
        IDataResult<List<SavedItemGetDto>> savedItemResult = await _savedItemService.GetAllAsync();
        ManageHomeVM vm = new()
        {
            UserResult = userResult.Data,
            ReviewResult=reviewResult.Data,
            SavedItemResult=savedItemResult.Data
        };
        return View(vm);
    }
}
