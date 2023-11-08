namespace BusinessLogicLayer.Services.Concrete;

public class SavedItemManager : ISavedItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SavedItemManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<SavedItemGetDto>>> GetAllAsync(params string[] includes)
    {
        List<SavedItem> savedItems = await _unitOfWork.SavedItemRepository.GetAllAsync(includes: includes);
        if (savedItems is null)
        {
            return new ErrorDataResult<List<SavedItemGetDto>>(Messages.NotFound(Messages.SavedItem));
        }
        return new SuccessDataResult<List<SavedItemGetDto>>(_mapper.Map<List<SavedItemGetDto>>(savedItems));
    }

    public async Task<IDataResult<List<SavedItemGetDto>>> GetAllByUserIdAsync(string id, params string[] includes)
    {
        List<SavedItem> savedItems = await _unitOfWork.SavedItemRepository.GetAllAsync(f => f.UserId == id, includes: includes);
        if (savedItems is null)
        {
            return new ErrorDataResult<List<SavedItemGetDto>>(Messages.NotFound(Messages.SavedItem));
        }
        return new SuccessDataResult<List<SavedItemGetDto>>(_mapper.Map<List<SavedItemGetDto>>(savedItems));
    }

    public  async Task<IDataResult<SavedItemGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        SavedItem savedItem = await _unitOfWork.SavedItemRepository.GetAsync(b => b.Id == id, includes);
        if (savedItem is null)
        {
            return new ErrorDataResult<SavedItemGetDto>(Messages.NotFound(Messages.SavedItem));
        }
        return new SuccessDataResult<SavedItemGetDto>(_mapper.Map<SavedItemGetDto>(savedItem));

    }
    #endregion


    #region Post Requests
    public async Task<IDataResult<SavedItemGetDto>> CreateAsync(SavedItemPostDto dto)
    {
        SavedItem savedItem = _mapper.Map<SavedItem>(dto);
        await _unitOfWork.SavedItemRepository.CreateAsync(savedItem);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<SavedItemGetDto>(Messages.NotCreated(Messages.SavedItem));
        }
        SavedItemGetDto getDto = _mapper.Map<SavedItemGetDto>(savedItem);
        getDto.BlogId = savedItem.BlogId;
        return new SuccessDataResult<SavedItemGetDto>(getDto, "Blog Added to Saved Items");
    }
    #endregion

    #region Delete Requests
    public async Task<Utilities.Results.IResult> HardDeleteByIdAsync(int id)
    {
        SavedItem savedItem = await _unitOfWork.SavedItemRepository.GetAsync(b => b.Id == id);
        _unitOfWork.SavedItemRepository.Delete(savedItem);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.SavedItem));
        }
        return new SuccessResult(Messages.Deleted(Messages.SavedItem));

    }

    #endregion

    #region Update Requests
    public async Task<Utilities.Results.IResult> UpdateAsync(SavedItemUpdateDto dto)
    {
        SavedItem savedItem = await _unitOfWork.SavedItemRepository.GetAsync(b => b.Id == dto.Id);
        savedItem = _mapper.Map<SavedItem>(dto);
        _unitOfWork.SavedItemRepository.Update(savedItem);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.SavedItem));
        }
        return new SuccessResult(Messages.Updated(Messages.SavedItem));
    }
    #endregion
}
