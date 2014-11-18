using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public abstract class Client<T> : IClient<T>
        where T : new()
    {
        public abstract T Create(Dictionary<string, string> parameters);

        public abstract T Show();

        public abstract IEnumerable<T> Index();

        public abstract T Update(Dictionary<string, string> parameters);

        public abstract bool Destroy(T item);

        public Task<T> ShowAsync()
        {
            return Task.Run<T>(() => Show());
        }

        public Task<IEnumerable<T>> IndexAsync()
        {
            return Task.Run<IEnumerable<T>>(() => Index());
        }

        public Task<bool> DestroyAsync(T item)
        {
            return Task.Run<bool>(() => Destroy(item));
        }

        protected IEnumerable<T> BuildTCollection(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new T();
            }
        }
    }
}
