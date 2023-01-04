using System.Collections;
using System.Collections.Generic;

namespace OnlineBookstore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
