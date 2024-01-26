using ProjectBooks.Data.Entities;

namespace ProjectBooks.Models.ViewModel
{
    public class AuthorBookVM
    {
        public Author author {  get; set; }

        public  Book books { get; set; } 
    }
}
