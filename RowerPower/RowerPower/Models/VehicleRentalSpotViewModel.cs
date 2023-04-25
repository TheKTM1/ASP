using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class VehicleRentalSpotViewModel {
        public int LocaleId { get; set; }
        [Display(Name = "Nazwa lokalu")]
        public string? LocaleName { get; set; }
        [Display(Name = "Adres lokalu")]
        public string? LocaleAddress { get; set; }
    }
}