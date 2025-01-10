using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14SNH.ConsoleApp4
{
    public class BlogHttpClientService
    {
        private readonly string endpoint = "https://localhost:7031/api/blog";
        private readonly HttpClient _httpClient;
        public BlogHttpClientService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<BlogListResponseModel> GetBlog()
        {
            //task so await use
            //JsonConverter ko install pay ya ml jsonconvert write p ctrl + . install
            //Json > C# Object
            //C# Object > C#
            
            //HttpClient client = new HttpClient();
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint); //? mean can be null

              
                String content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            return JsonConvert.DeserializeObject<BlogListResponseModel>(content)!;      //DeSerializeobject json to .net obj || SerializeObject .net obj to json;





        }

        public async Task<BlogResponseModel> GetBlog(string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            };
            return null;
        }

        public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
        {
            string jsonString = JsonConvert.SerializeObject(requestModel);
            var stringContent = new StringContent(jsonString,Encoding.UTF8,Application.Json);
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, stringContent);
            
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
 

        }

        public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
        {
            string jsonString = JsonConvert.SerializeObject(requestModel);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, Application.Json);
            HttpResponseMessage response = await _httpClient.PatchAsync($"{endpoint}/{requestModel.BlogId}", stringContent);

            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;


        }

        public async Task<BlogResponseModel> DeleteBlog(string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/{id}");
            
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            

        }
    }
}
