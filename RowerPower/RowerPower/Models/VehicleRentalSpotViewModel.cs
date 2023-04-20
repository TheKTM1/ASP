using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class VehicleRentalSpotViewModel {
        public int LocaleId { get; set; }
        [Display(Name = "Nazwa lokalu")]
        public string? LocaleName { get; set; }
        [Display(Name = "Adres lokalu")]
        public string? LocaleAddress { get; set; }
        public VehicleRentalSpotModel ToRentalSpotModel(VehicleRentalSpotViewModel rs) {
            var spot = new VehicleRentalSpotModel() {
                LocaleId = rs.LocaleId,
                LocaleName = rs.LocaleName,
                LocaleAddress = rs.LocaleAddress,
            };
            return spot;
        }
        public VehicleRentalSpotViewModel ToRentalSpotViewModel(VehicleRentalSpotModel rs) {
            var spot = new VehicleRentalSpotViewModel() {
                LocaleId = rs.LocaleId,
                LocaleName = rs.LocaleName,
                LocaleAddress = rs.LocaleAddress,
            };
            return spot;
        }
    }
}