using LibraryManagement.Helpers;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LibraryManagement.ViewModel
{
    public class UserHomePageViewModel : BaseViewModel
    {
        private byte[] _ImagePath;

        public byte[] ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; OnPropertyChanged(nameof(ImagePath)); }
        }

        private ObservableCollection<IssueBookModel> _BookList;

        public ObservableCollection<IssueBookModel> BookList
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

        private ObservableCollection<ReturnAlert> _ReturnAlertBooks;

        public ObservableCollection<ReturnAlert> ReturnAlertBooks
        {
            get
            {
                return _ReturnAlertBooks;
            }
            set
            {
                _ReturnAlertBooks = value;
                OnPropertyChanged(nameof(ReturnAlertBooks));
            }
        }

        public UserHomePageViewModel()
        {
            BookList = new ObservableCollection<IssueBookModel>();
            ReturnAlertBooks = new ObservableCollection<ReturnAlert>();
            getData();

        }

        public async void getData()
        {
         
            var data = await new IssueWebServices().GetIssueBooks();
            foreach (var ByteImages in data)
            {
                IssueBookModel pr = new IssueBookModel();
                pr.BookName = ByteImages.BookName;
                pr.BookPrice = ByteImages.BookPrice;
                pr.BookId = ByteImages.BookId;
                pr.IssueDate = ByteImages.IssueDate;
                pr.ReturnDate = ByteImages.ReturnDate;  
                pr.BookGenre = ByteImages.BookGenre;
                ImagePath = ByteImages.BookImage;
                pr.BookImage = ByteImages.BookImage;
                var stream1 = new MemoryStream(ByteImages.BookImage);
                pr.BookPath = ImageSource.FromStream(() => stream1);
                var ReturnDate = pr.ReturnDate.Value.AddDays(-3);
                var currdate = DateTime.Now;
                
                if (currdate >=  ReturnDate)
                {
                    ReturnAlert ra = new ReturnAlert();
                    ra.BookName = ByteImages.BookName;
                    ra.ReturnDate = ByteImages.ReturnDate;
                    ReturnAlertBooks.Add(ra);
                }
                BookList.Add(pr);
            }
            string message="";

            string alt = await SecureStorage.GetAsync("alert");
            if (ReturnAlertBooks != null)
            {
                if (alt == "")
                {
                    SecureStorage.SetAsync("alert", "alertShown");
                    App.Current.MainPage.Navigation.ShowPopup(new PopupCommunitiyToolkit(ReturnAlertBooks));
                }
            }
        }
    }
}
