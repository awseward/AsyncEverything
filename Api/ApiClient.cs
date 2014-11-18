using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace Api
{
    public class ApiClient<T> : Client<T>
        where T : new()
    {
        public override T Create(Dictionary<string, string> parameters)
        {
            Network.FakeDelay();
            return new T();
        }

        public override T Show()
        {
            Network.FakeDelay();
            return new T();
        }

        public override IEnumerable<T> Index()
        {
            Network.FakeDelay();
            return BuildTCollection(10);
        }

        public override T Update(Dictionary<string, string> parameters)
        {
            Network.FakeDelay();
            return new T();
        }

        public override bool Destroy(T item)
        {
            Network.FakeDelay();
            return true;
        }
    }
}
