using Microsoft.EntityFrameworkCore;
using RowerPower.Models;

namespace RowerPower.Repo {
    public class RentalSpotRepository : IRepository<VehicleRentalSpotModel> {
        private readonly VehicleDatabase _db;

        public RentalSpotRepository(VehicleDatabase db) {
            _db = db;
        }

        public VehicleRentalSpotModel? Get(int id) {
            return _db.RentalSpots.SingleOrDefault(x => x.LocaleId == id);
        }

        public void Delete(int id) {
            var toDelete = _db.RentalSpots.SingleOrDefault(x => x.LocaleId == id);
            if (toDelete != null) {
                _db.RentalSpots.Remove(toDelete);
            }
            _db.SaveChanges();
        }

        public void Update(VehicleRentalSpotModel entity) {
            var toUpdate = _db.RentalSpots.SingleOrDefault(x => x.LocaleId == entity.LocaleId);
            if (toUpdate != null) {
                _db.Entry(toUpdate).State = EntityState.Detached;
                _db.RentalSpots.Update(entity);
            }
            _db.SaveChanges();
        }

        public void Add(VehicleRentalSpotModel entity) {
            entity.LocaleId = _db.RentalSpots.Max(x => x.LocaleId) + 1;
            _db.RentalSpots.Add(entity);
            _db.SaveChanges();
        }

        public List<VehicleRentalSpotModel> GetAll() {
            return _db.RentalSpots.OrderBy(x => x.LocaleId).ToList();
        }
    }
}