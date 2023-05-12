using LibraryManagement.Helpers;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace LibraryManagement.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        private ObservableCollection<BooksResponse> _BookList;

        public ObservableCollection<BooksResponse> BookList
        {
            get
            {
                return _BookList;
            }
            set
            {
                _BookList = value;
                OnPropertyChanged(nameof(BookList));
            }
        }
        public HomePageViewModel()
        {
            BookList = new ObservableCollection<BooksResponse>();
          
          getData();
        }

        public async void getData()
        {

            var data = await new Webservices().GetUserBooks();
            foreach (var ByteImages in data)
            {
                BooksResponse pr = new BooksResponse();
                pr.BookName = ByteImages.BookName;
                pr.BookPrice = ByteImages.BookPrice;
                pr.BookId = ByteImages.BookId;
                pr.BookAvailable = ByteImages.BookAvailable;
                pr.BookDescription = ByteImages.BookDescription;
                pr.BookGenre = ByteImages.BookGenre;
                pr.BookQuantity = ByteImages.BookQuantity;
                pr.BookPath = ByteImages.BookImage;
                var stream1 = new MemoryStream(ByteImages.BookImage);
                pr.BookImage = ImageSource.FromStream(() => stream1);
                BookList.Add(pr);
            }      
        }
    }
}
