using AutoManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManage.Infra.Data.Mappings
{
    public class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(x => x.CpfCnpj, cpf =>
            {
                cpf.Property(c => c.Value)
                   .HasColumnName("CpfCnpj")
                   .HasMaxLength(14)
                   .IsRequired();
            });

            builder.Navigation(x => x.CpfCnpj).IsRequired();

            builder.HasIndex(x => x.CpfCnpj.Value)
                .IsUnique();

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(250);

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Value)
                     .HasColumnName("Email")
                     .HasMaxLength(150)
                     .IsRequired();
            });


            builder.Navigation(x => x.Email).IsRequired();

            builder.OwnsOne(x => x.PhoneNumber, phone =>
            {
                phone.Property(p => p.Value)
                     .HasColumnName("PhoneNumber")
                     .HasMaxLength(20)
                     .IsRequired();
            });

            builder.Navigation(x => x.PhoneNumber).IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasMany(x => x.Vehicles)
                .WithOne()
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
