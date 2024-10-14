using DivineSpark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DivineSpark.Services
{
    public class PostArmaService
    {
        private HttpClient httpClient;
        private PostArma post;
        Uri uri = new Uri("Nada Por enquanto");
        private ObservableCollection<PostArma> posts;
        private JsonSerializerOptions jsonSerializerOptions;

        public PostArmaService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<ObservableCollection<PostArma>> GetPostsAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<ObservableCollection<PostArma>>(content, jsonSerializerOptions);
                }
            }
            catch
            {

            }
            return posts;
        }

        public async Task<PostArma> SavePostAsync(PostArma item)
        {
            try
            {
                string json = JsonSerializer.Serialize<PostArma>(item, jsonSerializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(response.Content);
                }
            }
            catch (Exception e) 
            {
                Debug.WriteLine(e.Message);
            }
            return post;
        }     
    }
}
