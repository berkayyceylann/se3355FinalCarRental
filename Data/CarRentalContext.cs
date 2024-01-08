using VehicleRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace VehicleRentalSystem.Data
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {
        }

        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }
        public DbSet<OfficeModel> Offices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<RentalModel>()
                .HasKey(r => new { r.UserId, r.VehicleId });

            
            modelBuilder.Entity<RentalModel>()
                .HasOne(r => r.UserModel)
                .WithMany(u => u.Rentals)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<RentalModel>()
                .HasOne(r => r.VehicleModel)
                .WithMany(v => v.VehicleRentals)
                .HasForeignKey(r => r.VehicleId);
        }
    }
}