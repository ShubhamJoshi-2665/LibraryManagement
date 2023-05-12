using LibraryManagement.Helpers;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LibraryManagement.ViewModel
{
    public class IssueBookViewModel:BaseViewModel
    {
        private int _BookId;

        public int BookId
        {
            get { return _BookId; }
            set
            {
                _BookId = value;
                OnPropertyChanged(nameof(BookId));
            }
        }

        private string _BookName;

        public string BookName
        {
            get { return _BookName; }
            set
            {
                _BookName = value;
                OnPropertyChanged(nameof(BookName));
            }
        }

        private int _BookPrice;

        public int BookPrice
        {
            get { return _BookPrice; }
            set
            {
                _BookPrice = value;
                OnPropertyChanged(nameof(BookPrice));
            }
        }

        private string _BookCategory;

        public string BookCategory
        {
            get { return _BookCategory; }
            set
            {
                _BookCategory = value;
                OnPropertyChanged(nameof(BookCategory));
            }
        }

        private int _BookQuantity;

        public int BookQuantity
        {
            get { return _BookQuantity; }
            set
            {
                _BookQuantity = value;
                OnPropertyChanged(nameof(BookQuantity));
            }
        }

        private bool _BookAvailable;
        public bool BookAvailable
        {
            get { return _BookAvailable; }
            set
            {
                _BookAvailable = value;
                OnPropertyChanged(nameof(BookAvailable));
            }
        }
        private string _BookDescription;

        public string BookDescription
        {
            get { return _BookDescription; }
            set
            {
                _BookDescription = value;
                OnPropertyChanged(nameof(BookDescription));
            }
        }


        private DateTime _BookIssueDate;

        public DateTime BookIssueDate
        {
            get { return _BookIssueDate; }
            set
            {
                _BookIssueDate = value;
                OnPropertyChanged(nameof(BookIssueDate));
            }
        }
       

        private DateTime _BookReturnDate;

        public DateTime BookReturnDate
        {
            get { return _BookReturnDate; }
            set
            {
                _BookReturnDate = value;
                OnPropertyChanged(nameof(BookReturnDate));
            }
        }



        private byte[] _bookImage;
        public byte[] bookImage
        {
            get { return _bookImage; }
            set {
                _bookImage = value;
                OnPropertyChanged(nameof(bookImage));
            }
        }



        public Command IssueBook { get; set; }
        public Command ReturnDateSelected { get; set; }
        public Command IssueDateSelected { get; set; }
        public IssueBookViewModel()
        {
            IssueBook = new Command(Issue);
        }

     

        public IssueBookViewModel(BooksResponse data)
        {
            IssueBook = new Command(Issue);
            BookId = data.BookId;
            BookName = data.BookName;
            BookCategory = data.BookGenre;
            BookPrice = data.BookPrice;
            bookImage = data.BookPath;
        }
        
        public async void Issue()
        {
            IssueBookModel data = new IssueBookModel();
            data.BookName = BookName;
            data.BookPrice = BookPrice;
            data.BookGenre = BookCategory;
            data.IssueDate = BookIssueDate;
            data.ReturnDate = BookReturnDate;
            data.BookImage = bookImage;
            await new IssueWebServices().AddBook(data);
            App.Current.MainPage.Navigation.PopAsync();
        }

    }
}
