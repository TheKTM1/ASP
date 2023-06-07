using System.ComponentModel.DataAnnotations;

namespace RowerPower.Models {
    public class UserViewModel {
        public string Id { get; set; }
        [Display(Name = "Imię")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
        [Display(Name = "Hasło")]
        [Required]
        public string Password { get; set; }
    }
}
