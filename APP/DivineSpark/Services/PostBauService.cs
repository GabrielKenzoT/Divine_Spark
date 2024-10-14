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
    public class PostBauService
    {
        private HttpClient httpClient;
        private PostBau post;
        Uri uri = new Uri("Bau");
        private ObservableCollection<PostBau> posts;
        private JsonSerializerOptions jsonSerializerOptions;

        public PostBauService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<ObservableCollection<PostBau>> GetPostsAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<ObservableCollection<PostBau>>(content, jsonSerializerOptions);
                }
            }
            catch
            {

            }
            return posts;
        }
    }
}
