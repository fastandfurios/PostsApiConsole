using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PostsApiConsole.Client
{
    public class Client : IClient<Response, int>
    {
        internal HttpClient HttpClient { get; private set; }

        public Client(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<Response> GetPosts(int id)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get,
                $"https://jsonplaceholder.typicode.com/posts/{id}");

            try
            {
                var response = await HttpClient.SendAsync(httpRequest);

                await using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return await JsonSerializer.DeserializeAsync<Response>(responseStream, options);
            }
            catch(AggregateException e)
            {
                Debug.Write(e.Message);
            }

            return default;
        }
    }
}
