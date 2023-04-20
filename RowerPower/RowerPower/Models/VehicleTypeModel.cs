using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class VehicleTypeModel {
        [Key]
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
    }
}