using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsApiConsole.Repository
{
    public class Repository : IRepository<Response>
    {
        private string _fileName = "ListPosts.txt";

        public async Task SafeResultInFile(List<Response> listObjects)
        {
            try
            {
                await File.WriteAllLinesAsync(_fileName, listObjects.Select(s => s.ToString()));
            }
            catch (AggregateException e)
            {
                Debug.Write(e);
            }
        }
    }
}
