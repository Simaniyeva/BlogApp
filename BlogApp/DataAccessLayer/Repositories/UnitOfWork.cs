
namespace DataAccessLayer;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext _context;
    private IBlogImageRepository _blogImageRepository;
    private IBlogRepository _blogRepository;
    private ITagRepository _tagRepository;
    private ISavedItemRepository _savedItemRepository;
    private IReviewRepository _reviewRepository;
    private IBlogTagRepository _blogTagRepository;
    public UnitOfWork(AppDbContext context)
    {
        _context= context;
    }
    public IBlogRepository BlogRepository => _blogRepository = _blogRepository ?? new EFBlogRepository(_context);
    public IBlogTagRepository BlogTagRepository => _blogTagRepository = _blogTagRepository ?? new EFBlogTagRepository(_context);
    public ITagRepository TagRepository => _tagRepository = _tagRepository ?? new EFTagRepository(_context);
    public ISavedItemRepository SavedItemRepository => _savedItemRepository = _savedItemRepository ?? new EFSavedItemRepository(_context);
    public IReviewRepository ReviewRepository => _reviewRepository = _reviewRepository ?? new EFReviewRepository(_context);
    public IBlogImageRepository BlogImageRepository => _blogImageRepository = _blogImageRepository ?? new EFBlogImageRepository(_context);
    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
