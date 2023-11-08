
namespace DataAccessLayer.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>

{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.isDeleted).IsRequired().HasDefaultValue(false);
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        //Relations
        builder.HasMany(b => b.BlogTags).WithOne(b => b.Tag).HasForeignKey(b => b.TagId);
    }

}
