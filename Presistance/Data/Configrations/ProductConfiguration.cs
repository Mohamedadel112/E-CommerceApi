
namespace Presistance.Data.Configrations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.ProductType)
              .WithMany()
              .HasForeignKey(p => p.TypeId);

            builder.Property(p => p.Price).HasColumnType("decimal(8,3)");

            //builder.HasData();   // This Way To Insert Data Seeding into Database
        }
    }
}
