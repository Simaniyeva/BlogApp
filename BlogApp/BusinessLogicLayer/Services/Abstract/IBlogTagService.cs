using IResult = BusinessLogicLayer.Utilities.Results.IResult;

namespace BusinessLogicLayer.Services.Abstract;

public interface IBlogTagService
{
	Task<IDataResult<List<BlogTagGetDto>>> GetAllAsync(params string[] includes);
	Task<IDataResult<BlogTagGetDto>> GetByIdAsync(int id, params string[] includes);
	Task<IResult> CreateAsync(BlogTagPostDto dto);
	Task<IResult> UpdateAsync(BlogTagUpdateDto dto);
	Task<IResult> HardDeleteByIdAsync(int id);
}