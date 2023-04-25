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
    }
}