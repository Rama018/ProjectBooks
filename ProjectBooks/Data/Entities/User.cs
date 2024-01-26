using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBooks.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter The Name")]
        [DisplayName("Name")]
        [StringLength(200, ErrorMessage = "The Name value cannot exceed 200 characters. ")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please Enter The Email")]

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                             @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                             ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Required(ErrorMessage = "You must provide a phone number")]



        public string Phone { get; set; }

        [DataType(DataType.Password)]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CheckPassword { get; set; }

        public string Address { get; set; }

        public Customer? Customer { get; set; }

        public ICollection<Book> books { get; set; } = new List<Book>();

        public ICollection<BookUser> BookUserUser { get; set; } = new List<BookUser>();

        
       
    }
}
