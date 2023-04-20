using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class VehicleRentalSpotModel {
        [Key]
        public int LocaleId { get; set; }
        public string? LocaleName { get; set; }
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