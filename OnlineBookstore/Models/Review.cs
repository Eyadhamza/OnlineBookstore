namespace OnlineBookstore.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int BookID { get; set; }
        public int Stars { get; set; }
        public User User { get; set; }
    }
}
