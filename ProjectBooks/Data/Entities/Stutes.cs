namespace ProjectBooks.Data.Entities
{
    public class Stutes
    {
        public int ID { get; set; }

        public string StutesName { get; set;}

        public BookUser? User { get; set;}
    }
}
