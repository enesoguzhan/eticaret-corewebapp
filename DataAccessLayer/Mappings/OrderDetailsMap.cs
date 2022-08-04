namespace DataAccessLayer.Mappings
{
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.MainImages).HasMaxLength(50);
            builder.Property(x => x.Price).HasColumnType("money");

            builder.HasOne(x => x.Orders).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrdersId);

            builder.ToTable("OrderDetails");
        }
    }
}
