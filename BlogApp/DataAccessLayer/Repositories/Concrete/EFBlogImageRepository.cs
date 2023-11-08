namespace DataAccessLayer.Repositories.Concrete;

public class EFBlogImageRepository:EntityRepository<BlogImage,AppDbContext>,IBlogImageRepository
{
    private readonly AppDbContext _context;

    public EFBlogImageRepository(AppDbContext context) : base(context)
    {
        _context = context;    
    }
}
