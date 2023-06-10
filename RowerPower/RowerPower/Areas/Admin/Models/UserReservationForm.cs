using RowerPower.Models;

namespace RowerPower.Areas.Admin.Models {
    public class UserReservationFormPOST {
        public int ReserwejszynPojntAjdi { get; set; }
        public int WyporzyczanePedały { get; set; }
        public DateTime DataWypozyczenia { get; set; }
    }

    public class UserReservationFormGET {
        public List<VehicleRentalSpotViewModel> AutoPointy { get; set; }
        public List<VehicleItemViewModel> AutoAuto { get; set; }
    }
}