namespace RowerPower.Areas.Admin.Models {
    public class UserEditForm {
        public List<string> userRoles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}