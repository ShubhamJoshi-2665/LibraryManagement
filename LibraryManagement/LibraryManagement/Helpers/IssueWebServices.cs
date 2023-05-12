using LibraryManagement.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LibraryManagement.Helpers
{
    public  class IssueWebServices
    {
      
        public async Task<bool> AddBook(IssueBookModel book)
        {

            var jsonParam = JsonConvert.SerializeObject(book);
            HttpClient client = new HttpClient();
            Uri uristring = new Uri("http://192.168.2.126:8080/IssueBook/AddIssueBook");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uristring)
            {
                Content = new StringContent(jsonParam.Trim(), UnicodeEncoding.UTF8, "application/json")
            };
            var token = await SecureStorage.GetAsync("token");
            requestMessage.Headers.Add("Authorization", "Bearer " + token);

            HttpResponseMessage response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
           
            return true;
        }

        public async Task<ObservableCollection<IssueBookModel>> GetIssueBooks()
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uriString = new Uri("http://192.168.2.126:8080/IssueBook");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uriString);
                var token = await SecureStorage.GetAsync("token");
                requestMessage.Headers.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = await client.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();
                var rawJson = JsonConvert.DeserializeObject<ObservableCollection<IssueBookModel>>(content);
                return rawJson;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateBook(IssueBookModel book)
        {
            var jsonParam = JsonConvert.SerializeObject(book);
            HttpClient client = new HttpClient();
            Uri uristring = new Uri("http://192.168.2.126:8080/IssueBook/UpdateBook");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uristring)
            {
                Content = new StringContent(jsonParam.Trim(), UnicodeEncoding.UTF8, "application/json")
            };
            var token = await SecureStorage.GetAsync("token");
            requestMessage.Headers.Add("Authorization", "Bearer " + token);

            HttpResponseMessage response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            return true;
        }
        public async Task<bool> DeleteBook(int id)
        {
            
            HttpClient client = new HttpClient();
            Uri uristring = new Uri("http://192.168.2.126:8080/IssueBook/DeleteIssuedBook?id=" + id);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uristring);
            var token = await SecureStorage.GetAsync("token");
            requestMessage.Headers.Add("Authorization", "Bearer " + token);

            HttpResponseMessage response = await client.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            return true;
        }


    }
}
