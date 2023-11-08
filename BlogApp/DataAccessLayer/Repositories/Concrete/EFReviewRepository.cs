namespace DataAccessLayer.Repositories.Concrete;

public class EFReviewRepository : EntityRepository<Review, AppDbContext>, IReviewRepository
{
    private readonly AppDbContext _context;
    public EFReviewRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
