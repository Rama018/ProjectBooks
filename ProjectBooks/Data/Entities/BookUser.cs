namespace ProjectBooks.Data.Entities
{
    public class BookUser
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public int UserId { get; set; }

        public Book book { get; set; }

        public User user { get; set; }

        public int StutesId { get; set; }

        public Stutes Stutes { get; set; }
        

    }
}
