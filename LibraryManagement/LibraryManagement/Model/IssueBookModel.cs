using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LibraryManagement.Model
{
    public class IssueBookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookPrice { get; set; }
        public string BookGenre { get; set; }

        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public byte[] BookImage { get; set; }
        public ImageSource BookPath { get; set; }
    }
}
