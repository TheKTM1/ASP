using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class VehicleRentalSpotViewModel {
        public int LocaleId { get; set; }
        [Display(Name = "Nazwa lokalu")]
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public string LocaleName { get; set; }
        [Display(Name = "Adres lokalu")]
        [StringLength(30, ErrorMessage = "Pole adresu może zawierać od 8 do 30 znaków.", MinimumLength = 8)]
        public string? LocaleAddress { get; set; }
    }
}