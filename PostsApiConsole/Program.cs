using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PostsApiConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var client = new Client.Client(httpClient);
            var result = await client.GetPosts(4);
            Console.WriteLine($"{result.UserId}\n{result.Id}\n{result.Title}\n{result.Body}");
        }
    }
}
