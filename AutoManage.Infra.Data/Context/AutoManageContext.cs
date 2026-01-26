using AutoManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Infra.Data.Context
{
    public class AutoManageContext : DbContext
    {
        public AutoManageContext(DbContextOptions<AutoManageContext> options) : base(options) {}

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutoManageContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
