using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace RowerPower.Models {
    public class VehicleModel {
        [Key]
        public int VehicleId { get; set; }
        public string Name { get; set; }
        [ForeignKey("VehicleTypeModel")]
        public VehicleTypeModel? Type { get; set; }
        public string? Producer { get; set; }
        public decimal? Price { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
    }
}