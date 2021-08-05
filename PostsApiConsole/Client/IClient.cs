using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsApiConsole.Client
{
    public interface IClient<T, in TParameter> where T : class
    {
        Task<T> GetPosts(TParameter keyword);
    }
}
