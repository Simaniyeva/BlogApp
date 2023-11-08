using IResult = BusinessLogicLayer.Utilities.Results.IResult;

namespace BusinessLogicLayer.Services.Abstract;

public interface IBlogService:IGenericService<BlogGetDto,BlogPostDto,BlogUpdateDto>
{
    Task<IDataResult<List<BlogGetDto>>> GetAllPaginateAsync(int page, int size, bool getDeleted, params string[] includes);
    Task<IResult> IncreaseViewCount(int id);

}

