using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public interface IClient<T> where T : new()
    {
        T Show();
        IEnumerable<T> Index();
        bool Destroy(T item);

        Task<T> ShowAsync();
        Task<IEnumerable<T>> IndexAsync();
    }
}
