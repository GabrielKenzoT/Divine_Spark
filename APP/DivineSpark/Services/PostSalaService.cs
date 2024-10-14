using CommunityToolkit.Mvvm.Collections;
using DivineSpark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DivineSpark.Services
{
    public class PostSalaService
    {
        private HttpClient httpClient;
        private PostSala post;
        Uri uri = new Uri("Nada ainda");
        private ObservableCollection<PostSala> posts;
        private JsonSerializerOptions jsonSerializerOptions;

        public PostSalaService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<ObservableCollection<PostSala>> GetSalasAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode) 
                { 
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<ObservableCollection<PostSala>>(content, jsonSerializerOptions);
                }
            }
            catch
            {

            }
            return posts;
        }


    }
}
