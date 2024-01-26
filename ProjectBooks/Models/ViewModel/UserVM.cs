using System.ComponentModel.DataAnnotations;

namespace ProjectBooks.Models.ViewModel
{
    public class UserVM
    {

        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string CheckPassword { get; set; }

        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string userRole { get; set; }
        public enum UserRoleVM
        {
            Admin = 1,
            Customer = 2,
        }
    }
}
