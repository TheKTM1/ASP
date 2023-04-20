using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowerPower.Models {
    public class VehicleReservationModel {
        [Key]
        public int ReservationId { get; set; }
        [ForeignKey("VehicleModel")]
        public int VehicleId { get; set; }
        [ForeignKey("VehicleRentalSpotModel")]
        public int LocaleId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}