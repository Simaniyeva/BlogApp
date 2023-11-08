namespace DataAccessLayer.Repositories;

public interface IUnitOfWork:IDisposable
{
    public IBlogRepository BlogRepository { get; }
    public IBlogTagRepository BlogTagRepository { get; }
    public IBlogImageRepository BlogImageRepository { get; }
    public ITagRepository TagRepository { get; }
    public ISavedItemRepository SavedItemRepository { get; }
    public IReviewRepository ReviewRepository { get; }

    Task<int> SaveAsync();
}