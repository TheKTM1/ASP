using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RowerPower.Models {
    public class VehicleDetailViewModel {
        public int Id { get; set; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "Pole nie może być puste.")]
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
    }
}