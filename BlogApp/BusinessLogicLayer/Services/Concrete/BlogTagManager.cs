namespace BusinessLogicLayer.Services.Concrete;
public class BlogTagManager : IBlogTagService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BlogTagManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Get Requests
    public async Task<IDataResult<List<BlogTagGetDto>>> GetAllAsync(params string[] includes)
    {
        List<BlogTag> blogTags = await _unitOfWork.BlogTagRepository.GetAllAsync(includes: includes);
        if (blogTags is null) return new ErrorDataResult<List<BlogTagGetDto>>(Messages.NotFound(Messages.BlogTag));
        return new SuccessDataResult<List<BlogTagGetDto>>(_mapper.Map<List<BlogTagGetDto>>(blogTags));
    }

    public async Task<IDataResult<BlogTagGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        BlogTag blogTag = await _unitOfWork.BlogTagRepository.GetAsync(b => b.Id == id, includes);
        if (blogTag is null) return new ErrorDataResult<BlogTagGetDto>(Messages.NotFound(Messages.BlogTag));
        return new SuccessDataResult<BlogTagGetDto>(_mapper.Map<BlogTagGetDto>(blogTag));
    }

    #endregion


    #region Post Requests
    public async Task<Utilities.Results.IResult> CreateAsync(BlogTagPostDto dto)
    {
        BlogTag blogTag = _mapper.Map<BlogTag>(dto);
        await _unitOfWork.BlogTagRepository.CreateAsync(blogTag);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0) return new ErrorResult(Messages.NotCreated(Messages.BlogTag));
        return new SuccessResult(Messages.Created(Messages.BlogTag));
    }
    #endregion

    #region Update Requests
    public async Task<Utilities.Results.IResult> UpdateAsync(BlogTagUpdateDto dto)
    {
        BlogTag blogTag = await _unitOfWork.BlogTagRepository.GetAsync(b => b.Id == dto.Id);
        blogTag = _mapper.Map<BlogTag>(blogTag);
        _unitOfWork.BlogTagRepository.Update(blogTag);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0) return new ErrorResult(Messages.NotUpdated(Messages.BlogTag));
        return new SuccessResult(Messages.Updated(Messages.BlogTag));
    }


    #endregion

    #region Delete Requests
    public async Task<Utilities.Results.IResult> HardDeleteByIdAsync(int id)
    {
        BlogTag blogTag =await _unitOfWork.BlogTagRepository.GetAsync(b=>b.Id==id);
        _unitOfWork.BlogTagRepository.Delete(blogTag);
        int result = await _unitOfWork.SaveAsync();
        if (result is 0)  return new ErrorResult(Messages.NotDeleted(Messages.BlogTag));
        return new SuccessResult(Messages.Deleted(Messages.BlogTag));
    }
    #endregion

}