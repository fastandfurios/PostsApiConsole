using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsApiConsole
{
    public class Response
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public override string ToString()
            => $"{UserId}\n{Id}\n{Title}\n{Body.Replace("\n", " ")}\n";
    }
}
