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
    public partial class UserHomePage : ContentPage
    {
        protected override void OnAppearing()
        {
            BindingContext = new UserHomePageViewModel();
                      
            base.OnAppearing();
        }


        public UserHomePage()
        {
     
            InitializeComponent();
           
           
        }

        private void Logout(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        public IssueBookModel data = new IssueBookModel();


        private void IssueBookBtn(object sender, EventArgs e)
        {
            IssueBookFrame.BackgroundColor = Color.White;
            IssueBookLabel.TextColor = Color.FromHex("#3c5768");
            MyBookFrame.BackgroundColor = Color.FromHex("#3c5768");
            MyBookLabel.TextColor = Color.White;
            Navigation.PushAsync(new BooksList());
        }
        private void MyBooksBtn(object sender, EventArgs e)
        {
            MyBookFrame.BackgroundColor = Color.White;
            MyBookLabel.TextColor = Color.FromHex("#3c5768");
            IssueBookFrame.BackgroundColor = Color.FromHex("#3c5768");
            IssueBookLabel.TextColor = Color.White;
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            data = e.CurrentSelection.FirstOrDefault() as IssueBookModel;
        }

        private void EditBtn(object sender, EventArgs e)
        {
            var a = sender as Button;
            var data = (IssueBookModel)a.CommandParameter;
            
            Navigation.PushAsync(new EditIssueBook(data));
        }
    }
}