namespace DataAccessLayer.Repositories.Concrete;

public class EFBlogRepository : EntityRepository<Blog, AppDbContext>, IBlogRepository
{ 
    private readonly AppDbContext _context;
    public EFBlogRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
