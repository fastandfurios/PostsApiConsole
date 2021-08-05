using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsApiConsole.Repository
{
    public interface IRepository<T> where T : class
    {
        Task SafeResultInFile(List<T> listObjects);
    }
}
