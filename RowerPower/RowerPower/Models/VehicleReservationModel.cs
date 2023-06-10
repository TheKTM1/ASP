using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class VehicleReservationModel {
        [Key]
        public int ReservationId { get; set; }
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public VehicleModel Vehicle { get; set; }
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public VehicleRentalSpotModel LocaleId { get; set; }
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public UserModel User { get; set; }
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public DateTime ReservationDateStart { get; set; }
        public DateTime? ReservationDateFinish { get; set; }
    }
}