using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public interface IClient<T> where T : new()
    {
        T Create(Dictionary<string, string> parameters);
        T Show();
        IEnumerable<T> Index();
        T Update(Dictionary<string, string> parameters);
        bool Destroy(T item);

        Task<T> ShowAsync();
        Task<IEnumerable<T>> IndexAsync();
    }
}
