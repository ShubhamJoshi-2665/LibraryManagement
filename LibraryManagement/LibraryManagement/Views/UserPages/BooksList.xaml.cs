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

namespace LibraryManagement.Views.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksList : ContentPage
    {
        Books Record = new Books();
        public BooksList()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }
      
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var a = sender as Button;
            var data = (BooksResponse)a.CommandParameter;
            
            Navigation.PushAsync(new IssueBookPage(data));
        }

        
    }
}