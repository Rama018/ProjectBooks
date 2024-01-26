namespace ProjectBooks.Data.Entities
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

    }

}
