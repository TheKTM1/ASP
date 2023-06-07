using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class VehicleRentalSpotModel {
        [Key]
        public int LocaleId { get; set; }
        public string? LocaleName { get; set; }
        public string? LocaleAddress { get; set; }
    }
}