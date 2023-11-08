using IResult = BusinessLogicLayer.Utilities.Results.IResult;

namespace BusinessLogicLayer.Services.Concrete;

public class TagManager : ITagService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TagManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #region Get Requests
    public async Task<IDataResult<List<TagGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Tag> tags = getDeleted
            ? await _unitOfWork.TagRepository.GetAllAsync(includes: includes)
            : await _unitOfWork.TagRepository.GetAllAsync(b => !b.isDeleted, includes);
        if (tags is null)
        {
            return new ErrorDataResult<List<TagGetDto>>(Messages.NotFound(Messages.Tag));
        }
        return new SuccessDataResult<List<TagGetDto>>(_mapper.Map<List<TagGetDto>>(tags));
    }


    public async Task<IDataResult<TagGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Tag tag = await _unitOfWork.TagRepository.GetAsync(b => b.Id == id, includes);
        if (tag is null)
        {
            return new ErrorDataResult<TagGetDto>(Messages.NotFound(Messages.Tag));
        }
        return new SuccessDataResult<TagGetDto>(_mapper.Map<TagGetDto>(tag));
    }


    #endregion

    #region Post Requests

    public async Task<IResult> CreateAsync(TagPostDto dto)
    {
        Tag tag = _mapper.Map<Tag>(dto);
        await _unitOfWork.TagRepository.CreateAsync(tag);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotCreated(Messages.Tag));
        }
        return new SuccessResult(Messages.Created(Messages.Tag));
    }


    #endregion

    #region Update Requests

    public async Task<IResult> UpdateAsync(TagUpdateDto dto)
    {
        Tag tag = await _unitOfWork.TagRepository.GetAsync(b => b.Id == dto.Id && !b.isDeleted);
        tag = _mapper.Map<Tag>(dto);
        _unitOfWork.TagRepository.Update(tag);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Tag));
        }
        return new SuccessResult(Messages.Updated(Messages.Tag));
    }


    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Tag tag = await _unitOfWork.TagRepository.GetAsync(b => b.Id == id && b.isDeleted);
        tag.isDeleted = false;
        _unitOfWork.TagRepository.Update(tag);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Tag));
        }
        return new SuccessResult(Messages.Recovered(Messages.Tag));
    }

    #endregion

    #region Delete Requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Tag tag = await _unitOfWork.TagRepository.GetAsync(b => b.Id == id && b.isDeleted);
        _unitOfWork.TagRepository.Delete(tag);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Tag));
        }
        return new SuccessResult(Messages.Deleted(Messages.Tag));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Tag tag = await _unitOfWork.TagRepository.GetAsync(b => b.Id == id && !b.isDeleted);
        tag.isDeleted = true;
        _unitOfWork.TagRepository.Update(tag);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Tag));
        }
        return new SuccessResult(Messages.Deleted(Messages.Tag));
    }

    #endregion

}
