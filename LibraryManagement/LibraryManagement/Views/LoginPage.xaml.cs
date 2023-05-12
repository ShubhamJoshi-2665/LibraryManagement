using LibraryManagement.Views.AdminPages;
using LibraryManagement.Views.UserPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LibraryManagement.Model;
using Xamarin.Essentials;

namespace LibraryManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Navigation.PopToRootAsync();
        }

        private async Task<LoginResponseModel> Button_ClickedAsync()
        {
            LoginResponseModel res = new LoginResponseModel();
            try
            {
                Dictionary<string, string> list = new Dictionary<string, string>();
                list.Add("Username", username.Text);
                list.Add("Password", password.Text);
                string jsonParam = JsonConvert.SerializeObject(list);

                HttpClient client = new HttpClient();
                Uri uristring = new Uri("http://192.168.2.126:8080/api/Authenticate/login");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uristring)
                {
                    Content = new StringContent(jsonParam.Trim(), UnicodeEncoding.UTF8, "application/json")
                };


                HttpResponseMessage response = await client.SendAsync(requestMessage);

                var content = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<LoginResponseModel>(content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    await SecureStorage.SetAsync("token", res.token);
                    await SecureStorage.SetAsync("module", res.role);
                    string role2 = (string)module.SelectedItem;
                    if (res.role == "Admin")
                        Navigation.PushAsync(new HomePage());
                    else if (res.role == "User")
                        Navigation.PushAsync(new UserHomePage());
                    else
                    {
                        DisplayAlert("Alert", "Module Incorrect ", "ok");
                    }
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    username.Text = "";
                    password.Text = "";
                    DisplayAlert("Alert", "Invalid User Password", "ok");
                }
                else
                {
                    username.Text = "";
                    password.Text = "";
                    DisplayAlert("Alert", "Invalid User Password", "ok");
                }
                return res;
            }
            catch (Exception ex)
            {

                return res;
            }
            Navigation.PushAsync(new HomePage()) ;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button_ClickedAsync();
        }
    }
}