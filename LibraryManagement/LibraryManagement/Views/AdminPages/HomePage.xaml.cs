using LibraryManagement.Helpers;
using LibraryManagement.Model;
using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryManagement.Views.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        
        public BooksResponse data = new BooksResponse();
        public HomePage()
        {
            BindingContext = new HomePageViewModel();
            InitializeComponent();
         

            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
          
            (BindingContext as HomePageViewModel).getData();
        }


        private async void DeleteRecord(object sender, EventArgs e)
        {

            if (data.BookId != 0)
            {
                int id = data.BookId;
                await new Webservices().DeleteBook(id);
            }
            else
                DisplayAlert("Alert", "Kindly Select a Record", "Ok");
            // OnAppearing();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                data = e.CurrentSelection.FirstOrDefault() as BooksResponse;
        }

        private async void AddRecord(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddBook());
           
        }

        private void UpdateRecord(object sender, EventArgs e)
        {
            if (data.BookId != 0)
                Navigation.PushAsync(new AddBook(data));
            else
                DisplayAlert("Alert","Kindly Select a Record","Ok");
           
        }

        private void Logout(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}