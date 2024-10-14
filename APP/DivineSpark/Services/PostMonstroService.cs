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
    public class PostMonstroService
    {
        private HttpClient httpClient;
        private PostMonstro post;
        Uri uri = new Uri("Alguma outra coisa");
        private ObservableCollection<PostMonstro> posts;
        private JsonSerializerOptions jsonSerializerOpitons;

        public PostMonstroService()
        {
            httpClient = new HttpClient();
            jsonSerializerOpitons = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<ObservableCollection<PostMonstro>> GetPostMonstrosAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode) 
                { 
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<ObservableCollection<PostMonstro>>(content, jsonSerializerOpitons);
                }

            }
            catch
            {

            }
            return posts;
        }
    }
}
