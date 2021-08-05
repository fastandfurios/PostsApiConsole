using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace PostsApiConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var listResponses = await GetResponses();
            await SafeResult(listResponses);
            Console.WriteLine("Посты сохранены!");
        }

        private static async Task<List<Response>> GetResponses()
        {
            var httpClient = new HttpClient();
            var client = new Client.Client(httpClient);

            var tasks = new List<Task<Response>>();
            var listResponses = new List<Response>();

            var ids =Enumerable.Range(4, 10);

            ids.AsQueryable().ToList().ForEach(id => { tasks.Add(Task.Run(() => client.GetPosts(id))); });

            listResponses.AddRange(await Task.WhenAll(tasks));

            return listResponses;
        }

        private static async Task SafeResult(List<Response> list)
        {
            var repository = new Repository.Repository();

            await repository.SafeResultInFile(list);
        }
    }
}
