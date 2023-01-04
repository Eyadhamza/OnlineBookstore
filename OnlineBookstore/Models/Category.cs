using System;
using System.Collections.Generic;

namespace OnlineBookstore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
