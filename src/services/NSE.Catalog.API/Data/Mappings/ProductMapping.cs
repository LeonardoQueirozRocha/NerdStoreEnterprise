using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                   .IsRequired()
                   .HasColumnType("varchar(250)");

            builder.Property(product => product.Description)
                   .IsRequired()
                   .HasColumnType("varchar(500)");

            builder.Property(product => product.Image)
                   .IsRequired()
                   .HasColumnType("varchar(250)");

            builder.ToTable("Products");
        }
    }
}
