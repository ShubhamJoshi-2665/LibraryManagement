using LibraryManagement.Helpers;
using LibraryManagement.Model;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using Xamarin.Forms;

namespace LibraryManagement.Views.AdminPages
{
    public class AddBookViewModel:BaseViewModel
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

        private ImageSource imagePath;
        public ImageSource ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        private byte[] _ByteImage;
        public byte[] ByteImage
        {
            get { return _ByteImage; }
            set { _ByteImage = value; OnPropertyChanged(nameof(ByteImage)); }
        }

        public Command SelectImage { get; set; }
        public Command TakeImage { get; set; }
        public Command SaveBook { get; set; }
        public AddBookViewModel()
        {
            SaveBook= new Command(save);
            SelectImage = new Command(async ()=>{ PickPhoto(); });
            TakeImage = new Command(async ()=> { TakePhoto(); });
        }

        public async void TakePhoto()
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
            });
            using (BinaryReader br = new BinaryReader(file.GetStream()))            {
                ByteImage = br.ReadBytes((int)file.GetStream().Length);
            }
            ImagePath = ImageSource.FromFile(file.Path);
        }

        public async void PickPhoto()
        {
            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                CompressionQuality = 70, 
            }).ConfigureAwait(true);
            ImagePath = file.Path;
            if (file != null)
            {
                using (BinaryReader br = new BinaryReader(file.GetStream()))
                {
                    ByteImage = br.ReadBytes((int)file.GetStream().Length);
                }
            }
        }


        bool Update = false;

        public AddBookViewModel(BooksResponse data)
        {
            SaveBook = new Command(save);
            SelectImage = new Command(async () => { PickPhoto(); });
            TakeImage = new Command(async () => { TakePhoto(); });
            BookPrice = data.BookPrice;
             BookQuantity = data.BookQuantity;
             BookAvailable = data.BookAvailable;
            BookDescription = data.BookDescription;
            BookName = data.BookName;
             BookCategory = data.BookGenre;
             BookId = data.BookId;
            var stream1 = new MemoryStream(data.BookPath);
            ImagePath = ImageSource.FromStream(() => stream1);
           
            Update = true;
        }

        private void save()
        {
            Books data = new Books();
            data.BookId = BookId;
            data.BookPrice = BookPrice;
            data.BookQuantity = BookQuantity;
            data.BookAvailable = BookAvailable;
            data.BookDescription = BookDescription;
            data.BookName = BookName;
            data.BookGenre = BookCategory;
            data.BookImage = ByteImage;
            if (Update == true)
                new Webservices().UpdateBook(data);
            else
            new Webservices().AddBook(data);
            App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
    }
}