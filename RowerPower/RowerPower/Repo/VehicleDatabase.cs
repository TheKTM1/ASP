using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RowerPower.Models;

namespace RowerPower.Repo {
    public class VehicleDatabase : IdentityDbContext<UserModel, IdentityRole, string> {
        public DbSet<VehicleTypeModel> VehicleTypes { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<VehicleRentalSpotModel> RentalSpots { get; set; }
        public DbSet<VehicleReservationModel> VehicleReservations { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseInMemoryDatabase("VehicleDatabase");
        }

        public DbSet<RowerPower.Models.UserViewModel>? UserViewModel { get; set; }
    }
}