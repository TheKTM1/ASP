using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowerPower.Models {
    public class VehicleReservationModel {
        [Key]
        public int ReservationId { get; set; }
        [ForeignKey("VehicleModel")]
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public int VehicleId { get; set; }
        [ForeignKey("VehicleRentalSpotModel")]
        public int? LocaleId { get; set; }
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public DateTime ReservationDateStart { get; set; }
        public DateTime? ReservationDateFinish { get; set; }
    }
}