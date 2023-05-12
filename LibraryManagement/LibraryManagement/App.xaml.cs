using LibraryManagement.Views;
using LibraryManagement.Views.AdminPages;
using LibraryManagement.Views.UserPages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryManagement
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            check();
            
        }

        private async void check()
        {
            string role = await SecureStorage.GetAsync("module");
            if (role == "Admin")
            {
                MainPage = new NavigationPage(new HomePage());
            }
            else if (role == "User")
            {
                MainPage = new NavigationPage(new UserHomePage());
            }
            else
                MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            SecureStorage.SetAsync("alert", "");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
