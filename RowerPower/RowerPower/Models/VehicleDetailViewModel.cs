using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RowerPower.Models {
    public class VehicleDetailViewModel {
        public int Id { get; set; }
        [Display(Name = "Model")]
        public string Name { get; set; }
        [Display(Name = "Typ")]
        public VehicleTypeModel? Type { get; set; }
        [Display(Name = "Producent")]
        public string? Producer { get; set; }
        [Display(Name = "Cena")]
        public decimal? Price { get; set; }
        [Display(Name = "Wysokość")]
        public float? Height { get; set; }
        [Display(Name = "Waga")]
        public float? Weight { get; set; }
        [Display(Name = "Kolor")]
        public string? Color { get; set; }
        [Display(Name = "Opis")]
        public string? Description { get; set; }
        public VehicleModel ToVehicleModel(VehicleDetailViewModel v) {
            var vehicle = new VehicleModel() {
                VehicleId = v.Id,
                Name = v.Name,
                Type = v.Type,
                Producer = v.Producer,
                Price = v.Price,
                Height = v.Height,
                Weight = v.Weight,
                Color = v.Color,
                Description = v.Description
            };
            return vehicle;
        }
        public VehicleDetailViewModel ToVehicleDetailViewModel(VehicleModel v) {
            var vehicle = new VehicleDetailViewModel() {
                Id = v.VehicleId,
                Name = v.Name,
                Type = v.Type,
                Producer = v.Producer,
                Price = v.Price,
                Height = v.Height,
                Weight = v.Weight,
                Color = v.Color,
                Description = v.Description
            };
            return vehicle;
        }
    }
}