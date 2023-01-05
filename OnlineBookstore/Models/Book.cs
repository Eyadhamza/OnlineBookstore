using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineBookstore.Models
{
    public class Book
    {
        [BindNever]
        public int BookId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }

        public ICollection<Category>? Categories { get; set; }
        public ICollection<Author>? Authors { get; set; }
        public ICollection<Review>? Reviews { get; set; }

    }
}
