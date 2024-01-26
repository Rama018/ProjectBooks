namespace ProjectBooks.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public int? UserID { get; set; }

        public User? User { get; set; }
    }
}
