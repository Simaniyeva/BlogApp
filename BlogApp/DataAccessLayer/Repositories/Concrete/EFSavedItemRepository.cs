namespace DataAccessLayer.Repositories.Concrete;

public class EFSavedItemRepository : EntityRepository<SavedItem, AppDbContext>, ISavedItemRepository
{
    private readonly AppDbContext _context;
    public EFSavedItemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
