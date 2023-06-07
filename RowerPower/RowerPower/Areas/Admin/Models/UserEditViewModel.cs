using RowerPower.Models;

namespace RowerPower.Areas.Admin.Models {
    public class UserEditViewModel {
        public UserViewModel user { get; set; }
        public List<string> userRoles { get; set; }
    }
}