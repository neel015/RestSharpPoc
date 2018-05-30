using CallApiRestSharp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallApiRestSharp
{
    class Program
    {
        private const string apiUrl = "https://jsonplaceholder.typicode.com";
        static void Main(string[] args)
        {
           var jsonResponseFromGet =  CallGetApi();
           Console.BackgroundColor = ConsoleColor.Blue;
           Console.WriteLine(jsonResponseFromGet);
           var users = JsonConvert.DeserializeObject<List<User>>(jsonResponseFromGet);
           Console.WriteLine("------------------------------------");
           var jsonResponseFromPost = CallPostApi(users);
           Console.BackgroundColor = ConsoleColor.DarkGray;
           Console.WriteLine(jsonResponseFromPost);
           Console.ReadKey();
           
        }

        static string CallGetApi()
        {
            var restClient = new RestClient(apiUrl);
            var request = new RestRequest("users", Method.GET);
            var response = restClient.Execute(request);
            return response.Content;
        }

        static string CallPostApi(List<User> users)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest("users", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(users);
            var response = client.Execute(request);
            return response.Content;
        }
    }
}
