
namespace DataAccessLayer.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>

{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title).IsRequired();
        builder.Property(b => b.Description).IsRequired();  
        builder.Property(b=>b.ReadingTime).IsRequired();
        builder.Property(b=>b.ViewCount).HasDefaultValue(0);
        builder.Property(b=>b.isDeleted).IsRequired().HasDefaultValue(false);
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");



        //Relations
        builder.HasMany(b => b.BlogImages).WithOne(b => b.Blog).HasForeignKey(b => b.BlogId);
        builder.HasMany(b => b.Reviews).WithOne(b => b.Blog).HasForeignKey(b => b.BlogId);
        builder.HasMany(b => b.SavedItems).WithOne(b => b.Blog).HasForeignKey(b => b.BlogId);
        builder.HasMany(b => b.BlogTags).WithOne(b => b.Blog).HasForeignKey(b => b.BlogId);
    }

}
