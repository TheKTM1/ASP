using Microsoft.EntityFrameworkCore;
using RowerPower.Models;

namespace RowerPower.Repo {
    public class ReservationRepository : IRepository<VehicleReservationModel, int> {
        private readonly VehicleDatabase _db;

        public ReservationRepository(VehicleDatabase db) {
            _db = db;
        }

        public VehicleReservationModel? Get(int id) { 
            //dwie możliwości
            //a - wywalasz include'y (i tak w modelu są same inty (jest jeden string userID), więc samemu trzeba tworzyć relacje w kodzie
            //b - modyfikujesz model rezerwacji, by przyjmował obiekty, a nie inty/string
            //smaczngo dla jego tenk
            return _db.VehicleReservations.Include(x => x.Vehicle).Include(x => x.LocaleId).SingleOrDefault(x => x.ReservationId == id);
        }

        public void Delete(int id) {
            var toDelete = Get(id);
            if (toDelete != null) {
                _db.VehicleReservations.Remove(toDelete);
            }
            _db.SaveChanges();
        }

        public void Update(VehicleReservationModel entity) {
            var toUpdate = Get(entity.ReservationId);
            if (toUpdate != null) {
                _db.Entry(toUpdate).CurrentValues.SetValues(entity);
            }
            _db.SaveChanges();
        }

        public void Add(VehicleReservationModel entity) {
            entity.ReservationId = _db.VehicleReservations.Max(x => x.ReservationId) + 1;
            _db.VehicleReservations.Add(entity);
            _db.SaveChanges();
        }

        public List<VehicleReservationModel> GetAll() {
            return _db.VehicleReservations.Include(x => x.Vehicle).Include(x => x.LocaleId).OrderBy(x => x.ReservationId).ToList();
        }
    }
}
