using Microsoft.AspNetCore.Identity;

namespace RowerPower.Models {
    public class UserModel : IdentityUser<string> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}