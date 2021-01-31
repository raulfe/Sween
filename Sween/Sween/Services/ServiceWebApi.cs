using Newtonsoft.Json;
using Sween.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Services
{
    public class ServiceWebApi
    {
        const string WebApiURL = "https://sween.azurewebsites.net";
        const string SASQueryString = "";
        private static HttpClient Client = new HttpClient() { BaseAddress = new Uri(WebApiURL) };

        public static async Task<User> GetUserByCredentials(string user ,string password)
        {
            User dato = null;
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiURL}/api/Users/GetUsersByCredential/{user}/{password}";
            var respuesta = await Client.GetAsync(url);
            if(respuesta.StatusCode == HttpStatusCode.OK)
            {
                var json = await respuesta.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    dato = JsonConvert.DeserializeObject<User>(json);
                    dato.ImageURLSAS = $"{dato.ImageURL.ToString()}{SASQueryString}";
                }
            }
            return dato;
        }

        public static async Task<User> GetUser(int id,string dt)
        {
            User dato = null;
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiURL}/api/Users/{id}";
            var respuesta = await Client.GetAsync(url);
            if(respuesta.StatusCode == HttpStatusCode.OK)
            {
                var json = await respuesta.Content.ReadAsStringAsync();
                dato = JsonConvert.DeserializeObject<User>(json);
                dato.ImageURLSAS = new ServiceStorage().GetFullUserURL(dato.IdUser, dt);
            }
            return dato;
        }


        public static async Task<User> InsertUser(User user)
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiURL}/api/Users";
            var jsonContent = JsonConvert.SerializeObject(user);
            var respuesta = await Client.PostAsync(url, new StringContent(jsonContent.ToString(),Encoding.UTF8,"application/json"));
            if (!respuesta.IsSuccessStatusCode)
            {
                return null;
            }
            return user;
        }

        public static async Task UpdateUser(User info, MemoryStream stream, string dt)
        {
            if (stream != null)
            {
                var servicioStorage = new ServiceStorage();
                info.ImageURL = await servicioStorage.UploadUser(info.IdUser.Value, stream, dt);
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiURL}/api/Users/{info.IdUser}";
            var jsonContent = JsonConvert.SerializeObject(info);
            var respuesta = await Client.PutAsync(url, new StringContent(jsonContent.ToString(), Encoding.UTF8, "application/json"));
            
            
        }


    }
}
