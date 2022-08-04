namespace DataAccessLayer.Mappings
{
    public class CategoriesMap :IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s=>s.Id).ValueGeneratedOnAdd();
            builder.Property(s=>s.Name).HasMaxLength(50);

            builder.HasMany(s => s.Products).WithOne(s => s.Categories).HasForeignKey(s => s.CategoriesId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Categories");
        }
    }
}
