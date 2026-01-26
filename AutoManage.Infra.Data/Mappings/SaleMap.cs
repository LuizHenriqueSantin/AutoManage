using AutoManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Infra.Data.Mappings
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SaleDate)
                .IsRequired();

            builder.Property(s => s.FinalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            builder.HasOne(x => x.Seller)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Vehicle)
                .WithOne()
                .HasForeignKey<Sale>(s => s.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
