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
    public class PostPersonagemService
    {
        private HttpClient httpClient;
        private PostPersonagem post;
        Uri uri = new Uri("Alguma");
        private ObservableCollection<PostPersonagem> posts;
        private JsonSerializerOptions jsonSerializerOptions;

        public PostPersonagemService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<ObservableCollection<PostPersonagem>> GetPostsAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode) 
                {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<ObservableCollection<PostPersonagem>>(content, jsonSerializerOptions);
                }

            }
            catch
            {

            }
            return posts;
        }

        public async Task<PostPersonagem> SavePostAsync(PostPersonagem item)
        {
            try
            {
                string json = JsonSerializer.Serialize<PostPersonagem>(item, jsonSerializerOptions);
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
