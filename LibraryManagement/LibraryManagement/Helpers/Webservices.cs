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
    public class Webservices
    {
        public async Task<ObservableCollection<Books>> GetBooks()
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uriString = new Uri("http://192.168.2.126:8080/AdminLibrary");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uriString);
                var token = await SecureStorage.GetAsync("token");
                requestMessage.Headers.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = await client.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();
                var rawJson = JsonConvert.DeserializeObject<ObservableCollection<Books>>(content);
                return rawJson;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ObservableCollection<Books>> GetUserBooks()
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uriString = new Uri("http://192.168.2.126:8080/api/UserLibrary/GetUserBooks");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uriString);
                var token = await SecureStorage.GetAsync("token");
                requestMessage.Headers.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = await client.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();
                var rawJson = JsonConvert.DeserializeObject<ObservableCollection<Books>>(content);
                return rawJson;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<bool> DeleteBook( int id)
        {
            HttpClient client = new HttpClient();
            Uri uristring = new Uri("http://192.168.2.126:8080/AdminLibrary/deleteBook?id=" + id);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uristring);
            var token = await SecureStorage.GetAsync("token");
            requestMessage.Headers.Add("Authorization", "Bearer " + token);
            HttpResponseMessage response = await client.SendAsync(requestMessage);
            var a = 30;
            return true;

        }


        public async Task<bool> AddBook( Books book)
        {
            
                var jsonParam = JsonConvert.SerializeObject(book);
                HttpClient client = new HttpClient();
                Uri uristring = new Uri("http://192.168.2.126:8080/AdminLibrary/AddBook");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uristring)
                {
                    Content = new StringContent(jsonParam.Trim(), UnicodeEncoding.UTF8, "application/json")
                };
            var token = await SecureStorage.GetAsync("token");
            requestMessage.Headers.Add("Authorization", "Bearer " + token);

            HttpResponseMessage response = await client.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();
               var rawJson = JsonConvert.DeserializeObject<ObservableCollection<Books>>(content);
            return true;
            }
        public async Task<bool> UpdateBook( Books book)
        {
                var jsonParam = JsonConvert.SerializeObject(book);
                HttpClient client = new HttpClient();
                Uri uristring = new Uri("http://192.168.2.126:8080/AdminLibrary/UpdateBook");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uristring)
                {
                    Content = new StringContent(jsonParam.Trim(), UnicodeEncoding.UTF8, "application/json")
                };
            var token = await SecureStorage.GetAsync("token");
            requestMessage.Headers.Add("Authorization", "Bearer " + token);

            HttpResponseMessage response = await client.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();
               var rawJson = JsonConvert.DeserializeObject<ObservableCollection<Books>>(content);
            return true;
            }

        
    }
    }


