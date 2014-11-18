using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Api
{
    public class Client<T> where T : new()
    {
        public T Show()
        {
            Network.FakeDelay();
            return new T();
        }

        public Task<T> ShowAsync()
        {
            return Task.Run<T>(() => Show());
        }

        public IEnumerable<T> Index()
        {
            Network.FakeDelay();
            return BuildIndex().ToArray();
        }

        public Task<IEnumerable<T>> IndexAsync()
        {
            return Task.Run<IEnumerable<T>>(() => Index());
        }

        public T Fail()
        {
            Network.FakeDelay();
            throw Network.GetRandomWebException();
        }

        public Task<T> FailAsync()
        {
            return Task.Run<T>(() => Fail());
        }

        private IEnumerable<T> BuildIndex()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new T();
            }
        }
    }
}
