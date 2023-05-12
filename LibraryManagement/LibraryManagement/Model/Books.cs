using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Model
{
    public class Books
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookPrice { get; set; }

        public string BookGenre { get; set; }
        public string BookDescription { get; set; }
        public bool BookAvailable { get; set; }
        public int BookQuantity { get; set; }
        public byte[] BookImage { get; set; }
    }
}
