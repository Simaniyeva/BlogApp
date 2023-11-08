namespace DataAccessLayer.Repositories.Concrete;

public class EFTagRepository : EntityRepository<Tag, AppDbContext>, ITagRepository
{
    private readonly AppDbContext _dbContext;
    public EFTagRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }
}
