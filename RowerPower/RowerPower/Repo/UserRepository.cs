using Microsoft.EntityFrameworkCore;
using RowerPower.Models;

namespace RowerPower.Repo {
    public class UserRepository : IRepository<UserModel, string> {

        private readonly VehicleDatabase _db;

        public UserRepository(VehicleDatabase db) {
            _db = db;
        }

        public UserModel? Get(string id) {
            return _db.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Delete(string id) {
            var toDelete = _db.Users.SingleOrDefault(x => x.Id == id);
            if (toDelete != null) {
                _db.Users.Remove(toDelete);
            }
            _db.SaveChanges();
        }

        public void Update(UserModel user) {
            var toUpdate = _db.Users.SingleOrDefault(x => x.Id == user.Id);
            if (toUpdate != null) {
                _db.Entry(toUpdate).State = EntityState.Detached;
                _db.Users.Update(user);
            }
            _db.SaveChanges();
        }

        public void Add(UserModel user) {
            user.Id = _db.Users.Max(x => x.Id) + 1;
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public List<UserModel> GetAll() {
            return _db.Users.OrderBy(x => x.Id).ToList();
        }

    }
}
