using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowerPower.Models {
    public class VehicleReservationViewModel {
        public int ReservationId { get; set; }
        [Display(Name = "Nr pojazdu")]
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public int VehicleId { get; set; }
        [Display(Name = "Nr lokalu")]
        public int? LocaleId { get; set; }
        [Display(Name = "Data rozpoczęcia rezerwacji")]
        [Required(ErrorMessage = "Pole nie może być puste.")]
        [Range(typeof(DateTime), "1/1/2020", "1/1/2051", ErrorMessage = "Data rozpoczęcia rezerwacji musi zawierać się w latach z przedziału 2020-2050.")]
        public DateTime ReservationDateStart { get; set; }
        [Display(Name = "Data zakończenia rezerwacji")]
        [Range(typeof(DateTime), "1/1/2020", "1/1/2051", ErrorMessage = "Termin upłynięcia rezerwacji musi zawierać się w latach z przedziału 2020-2050.")]
        public DateTime? ReservationDateFinish { get; set; }
    }
}
