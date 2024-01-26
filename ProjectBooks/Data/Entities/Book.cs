namespace ProjectBooks.Data.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }


        public int AuthorID { get; set; }

        public Author author { get; set; }

        public ICollection<User> users { get; set; } = new List<User>();

        public ICollection<BookUser> BookUserBook { get; set; } = new List<BookUser>();



    }
}
