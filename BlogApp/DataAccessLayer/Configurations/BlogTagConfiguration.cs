
namespace DataAccessLayer.Configurations;

public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>

{
    public void Configure(EntityTypeBuilder<BlogTag> builder)
    {
        builder.HasKey(b => b.Id);

        //Relations
        builder.HasOne(b => b.Blog).WithMany(b => b.BlogTags).HasForeignKey(b => b.BlogId);
        builder.HasOne(b => b.Tag).WithMany(b => b.BlogTags).HasForeignKey(b => b.TagId);
    }

}