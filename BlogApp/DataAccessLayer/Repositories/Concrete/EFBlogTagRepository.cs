namespace DataAccessLayer.Repositories.Concrete;

public class EFBlogTagRepository : EntityRepository<BlogTag, AppDbContext>, IBlogTagRepository
{
    private readonly AppDbContext _context;
    public EFBlogTagRepository(AppDbContext context) : base(context)
    {
        _context = context; 
    }
}
