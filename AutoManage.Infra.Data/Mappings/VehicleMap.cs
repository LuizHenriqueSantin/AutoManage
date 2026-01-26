using AutoManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Infra.Data.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Chassis)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(v => v.Chassis)
                .IsUnique();

            builder.Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Year)
                .IsRequired();

            builder.Property(v => v.Color)
                .IsRequired();

            builder.Property(v => v.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(v => v.Mileage)
                .IsRequired();

            builder.Property(v => v.SystemVersion)
                .IsRequired();

            builder.Property(v => v.CreatedAt)
                .IsRequired();

            builder.HasOne(x => x.Owner)
                .WithMany(o => o.Vehicles)
                .HasForeignKey(v => v.OwnerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Sale)
                .WithOne(s => s.Vehicle)
                .HasForeignKey<Sale>(s => s.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
