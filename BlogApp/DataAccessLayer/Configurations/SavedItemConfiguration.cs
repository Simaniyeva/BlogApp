
namespace DataAccessLayer.Configurations;

public class SavedItemConfiguration : IEntityTypeConfiguration<SavedItem>

{
    public void Configure(EntityTypeBuilder<SavedItem> builder)
    {
        builder.HasKey(b => b.Id);

        //Relations
        builder.HasOne(c => c.Blog).WithMany(c => c.SavedItems).HasForeignKey(c => c.BlogId);
        builder.HasOne(c => c.User).WithMany(c => c.SavedItems).HasForeignKey(c => c.UserId);

    }

}
