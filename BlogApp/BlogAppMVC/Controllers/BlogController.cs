using Entities.DTOs.SavedItem;
using Microsoft.AspNetCore.Mvc;
using IResult = BusinessLogicLayer.Utilities.Results.IResult;

namespace BlogAppMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IAccountService _accountService;
        private readonly ISavedItemService _savedItemService;
        private readonly IReviewService _reviewService;

        public BlogController(IAccountService accountService, ISavedItemService savedItemService, IReviewService reviewService, IBlogService blogService)
        {
            _accountService = accountService;
            _savedItemService = savedItemService;
            _reviewService = reviewService;
            _blogService = blogService;
        }

        public async Task<IActionResult> Get(int id)
        {
            IDataResult<BlogGetDto> result = await _blogService.GetByIdAsync(id, Includes.BlogIncludes);
            await _blogService.IncreaseViewCount(id);
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> WriteComment(ReviewPostDto dto)
        {
            dto.UserId = (await _accountService.GetUserByClaims(User)).Data.Id;
            IResult result = await _reviewService.CreateAsync(dto);
            return RedirectToAction("Get", "Blog", new { id = dto.BlogId });
        }

        public async Task<IActionResult> GetRelated()
        {
            IDataResult<List<BlogGetDto>> result = await _blogService.GetAllAsync(false, "BlogImages");
            List<BlogGetDto> related = result.Data.OrderByDescending(x=>x.Id).ToList();
            return PartialView("_latestBlogListPartial", related);
        }


        #region SavedItem
        [HttpPost]
        public async Task<IDataResult<SavedItemGetDto>> AddToSaved(int id)
        {
            SavedItemPostDto dto = new()
            {
                BlogId = id,
                UserId = (await _accountService.GetUserByClaims(User, Includes.UserIncludes)).Data.Id
            };

            var result = await _savedItemService.CreateAsync(dto);
            return result;
        }
        [HttpPost]
        //[Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IResult> RemoveFromSavedItem(int id)
        {
            var result = await _savedItemService.HardDeleteByIdAsync(id);
            return result;
        }

        #endregion



    }
}
