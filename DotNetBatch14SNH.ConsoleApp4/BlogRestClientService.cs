using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using RestSharp;

namespace DotNetBatch14SNH.ConsoleApp4
{
    public class BLogRestClientService
    {
        private readonly string endpoint = "https://localhost:7031/api/blog";
        private readonly RestClient _restClient;
                                
            
        public BLogRestClientService()
        {
            _restClient = new RestClient();
        }
        public async Task<BlogListResponseModel> GetBlog()
        {
            //task so await use
            //JsonConverter ko install pay ya ml jsonconvert write p ctrl + . install
            //Json > C# Object
            //C# Object > C#
            
            //HttpClient client = new HttpClient();
            RestRequest request = new RestRequest(endpoint,Method.Get);
            var response = await _restClient.ExecuteAsync(request); //? mean can be null
            string content = response.Content!;
              
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<BlogListResponseModel>(content)!;      //DeSerializeobject json to .net obj || SerializeObject .net obj to json;



        }

        public async Task<BlogResponseModel> GetBlog(string id)
        {
            RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Get);

            var response = await _restClient.ExecuteAsync(request);
            
                string content = response.Content!;
                Console.WriteLine(content);
                return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
           
        }

        public async Task<BlogResponseModel> CreateBlog(BlogModel requestModel)
        {
            RestRequest request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(requestModel);
            var response = await _restClient.ExecuteAsync(request);

            string content = response.Content!;
                Console.WriteLine(content);
                return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
 

        }

        public async Task<BlogResponseModel> UpdateBlog(BlogModel requestModel)
        {

            RestRequest request = new RestRequest($"{endpoint}/{requestModel.BlogId}", Method.Patch);
            request.AddJsonBody(requestModel);
            
           var response = await _restClient.ExecuteAsync(request); 
            string content = response.Content!;
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;


        }

        public async Task<BlogResponseModel> DeleteBlog(string id)
        {
            RestRequest request = new RestRequest($"{endpoint}/{id}",Method.Delete);
           var response = await _restClient.ExecuteAsync(request);
            string content = response.Content!;
           
                Console.WriteLine(content);
                return JsonConvert.DeserializeObject<BlogResponseModel>(content)!;
            

        }
    }
}
