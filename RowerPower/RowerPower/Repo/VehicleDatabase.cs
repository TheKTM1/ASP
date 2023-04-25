using Microsoft.EntityFrameworkCore;
using RowerPower.Models;

namespace RowerPower.Repo {
    public class VehicleDatabase : DbContext {
        public DbSet<VehicleTypeModel> VehicleTypes { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<VehicleRentalSpotModel> RentalSpots { get; set; }
        public DbSet<VehicleReservationModel> VehicleReservations { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseInMemoryDatabase("VehicleDatabase");
        }
    }
}