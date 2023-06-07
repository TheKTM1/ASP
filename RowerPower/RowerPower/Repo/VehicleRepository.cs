using Microsoft.EntityFrameworkCore;
using RowerPower.Models;

namespace RowerPower.Repo {
    public class VehicleRepository : IRepository<VehicleModel, int> {
        private readonly VehicleDatabase _db;

        public VehicleRepository(VehicleDatabase db) {
            _db = db;
        }

        public VehicleModel? Get(int id) {
            return _db.Vehicles.Include(x => x.Type).SingleOrDefault(x => x.VehicleId == id);
        }

        public void Delete(int id) { 
            var toDelete = _db.Vehicles.SingleOrDefault(x => x.VehicleId == id);
            if (toDelete != null) {
                _db.Vehicles.Remove(toDelete);
            }
            _db.SaveChanges();
        }

        public void Update(VehicleModel entity) {
            var toUpdate = _db.Vehicles.SingleOrDefault(x => x.VehicleId == entity.VehicleId);
            if (toUpdate != null) {
                _db.Entry(toUpdate).State = EntityState.Detached;
                _db.Vehicles.Update(entity);
            }
            _db.SaveChanges();
        }

        public void Add(VehicleModel entity) { 
            entity.VehicleId = _db.Vehicles.Max(x => x.VehicleId) + 1;
            _db.Vehicles.Add(entity);
            _db.SaveChanges();
        }

        public List<VehicleModel> GetAll() { 
            return _db.Vehicles.Include(x => x.Type).OrderBy(x => x.VehicleId).ToList();
        }
    }
}