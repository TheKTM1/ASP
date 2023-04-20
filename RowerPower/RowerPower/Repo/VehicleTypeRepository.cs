using Microsoft.EntityFrameworkCore;
using RowerPower.Models;

namespace RowerPower.Repo {
    public class VehicleTypeRepository : IRepository<VehicleTypeModel> {
        private readonly VehicleDatabase _db;

        public VehicleTypeRepository(VehicleDatabase db) { 
            _db = db;
        }

        public VehicleTypeModel? Get(int id) {
            return _db.VehicleTypes.SingleOrDefault(x => x.VehicleTypeId == id);
        }

        public void Delete(int id) {
            var toDelete = _db.VehicleTypes.SingleOrDefault(x => x.VehicleTypeId == id);
            if (toDelete != null) { 
                _db.VehicleTypes.Remove(toDelete);
            }
            _db.SaveChanges();
        }

        public void Update(VehicleTypeModel entity) {
            var toUpdate = _db.VehicleTypes.SingleOrDefault(x => x.VehicleTypeId == entity.VehicleTypeId);
            if (toUpdate != null) {
                _db.VehicleTypes.Update(entity);
            }
            _db.SaveChanges();
        }

        public void Add(VehicleTypeModel entity) { 
            entity.VehicleTypeId = _db.VehicleTypes.Max(x => x.VehicleTypeId) + 1;
            _db.VehicleTypes.Add(entity);
            _db.SaveChanges();
        }

        public List<VehicleTypeModel> GetAll() { 
            return _db.VehicleTypes.OrderBy(x => x.VehicleTypeId).ToList();
        }
    }
}
