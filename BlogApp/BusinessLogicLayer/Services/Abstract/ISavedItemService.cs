
using IResult = BusinessLogicLayer.Utilities.Results.IResult;

namespace BusinessLogicLayer.Services.Abstract;

public interface ISavedItemService
{
    #region Get Requests
    Task<IDataResult<List<SavedItemGetDto>>> GetAllAsync(params string[] includes);
    Task<IDataResult<List<SavedItemGetDto>>> GetAllByUserIdAsync(string id, params string[] includes);
    Task<IDataResult<SavedItemGetDto>> GetByIdAsync(int id, params string[] includes);
    #endregion

    #region Create Requests
    Task<IDataResult<SavedItemGetDto>> CreateAsync(SavedItemPostDto dto);

    #endregion

    #region Update Requests
    Task<IResult> UpdateAsync(SavedItemUpdateDto dto);

    #endregion

    #region Delete Requests
    Task<IResult> HardDeleteByIdAsync(int id);
    #endregion
}