
namespace DataAccessLayer.Configurations;

public class BlogImageConfiguration : IEntityTypeConfiguration<BlogImage>

{
    public void Configure(EntityTypeBuilder<BlogImage> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.isDeleted).IsRequired().HasDefaultValue(false);
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        builder.HasOne(b => b.Blog).WithMany(b => b.BlogImages).HasForeignKey(b => b.BlogId);
    }

}