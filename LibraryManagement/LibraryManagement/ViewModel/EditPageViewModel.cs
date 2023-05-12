using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.ViewModel
{
    using global::LibraryManagement.Helpers;
    using global::LibraryManagement.Model;
    
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    namespace LibraryManagement.ViewModel
    {
        public class EditPageViewModel : BaseViewModel
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

            private ImageSource _bookImage;
            public ImageSource bookImage
            {
                get { return _bookImage; }
                set
                {
                    _bookImage = value;
                    OnPropertyChanged(nameof(bookImage));
                }
            }

            private byte[] _bookPath;
            public byte[] bookPath
            {
                get { return _bookPath; }
                set
                {
                    _bookPath = value;
                    OnPropertyChanged(nameof(bookPath));
                }
            }



            public Command UpdateIssueBook { get; set; }
            public ICommand DeleteIssueBook { get; set; }
            
            public EditPageViewModel(IssueBookModel data)
            {
                UpdateIssueBook = new Command(UpdateBook);
                DeleteIssueBook = new Command(DeleteBook);
                getData(data);
            }
            public void getData(IssueBookModel data)
            {
                BookId = data.BookId;
                BookName = data.BookName;
                BookCategory = data.BookGenre;
                BookIssueDate = data.IssueDate.Value;
                BookReturnDate = data.ReturnDate.Value;
                BookPrice = data.BookPrice;
                bookPath = data.BookImage;
                var stream1 = new MemoryStream(data.BookImage);
                bookImage = ImageSource.FromStream(() => stream1);
            }
            public async void UpdateBook()
            {
                IssueBookModel data = new IssueBookModel();
                data.ReturnDate = BookReturnDate;
                data.BookImage= bookPath;
                data.BookId = BookId;
                data.BookName = BookName;
                data.BookGenre = BookCategory;
                data.IssueDate = BookIssueDate;
                await new IssueWebServices().UpdateBook(data);
                App.Current.MainPage.Navigation.PopAsync();
            }
            public async void DeleteBook()
            {
                IssueBookModel data = new IssueBookModel();
               
               int id = (int)BookId;
               
                await new IssueWebServices().DeleteBook(id);
                App.Current.MainPage.Navigation.PopAsync();
            }

        }
    }

}
