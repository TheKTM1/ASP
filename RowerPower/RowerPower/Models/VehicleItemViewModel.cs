using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class VehicleItemViewModel {
        public int Id { get; set; }
        [Display(Name = "Model")]
        public string Name { get; set; }
        [Display(Name = "Typ")]
        public VehicleTypeModel Type { get; set; }
        [Display(Name = "Producent")]
        public string? Producer { get; set; }
        [Display(Name = "Cena")]
        public decimal? Price { get; set; }
        public VehicleModel ToVehicleModel(VehicleItemViewModel v) {
            var vehicle = new VehicleModel() {
                VehicleId= v.Id,
                Name = v.Name,
                Type = v.Type,
                Producer = v.Producer,
                Price = v.Price
            };
            return vehicle;
        }
        public VehicleItemViewModel ToVehicleItemViewModel(VehicleModel v) {
            var vehicle = new VehicleItemViewModel() {
                Id = v.VehicleId,
                Name = v.Name,
                Type = v.Type,
                Producer = v.Producer,
                Price = v.Price
            };
            return vehicle;
        }
    }
}