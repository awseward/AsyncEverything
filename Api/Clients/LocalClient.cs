using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class LocalClient<T> : Client<T>
        where T : new()
    {
        public override T Create(Dictionary<string, string> parameters)
        {
            return new T();
        }

        public override T Show()
        {
            return new T();
        }

        public override IEnumerable<T> Index()
        {
            return BuildTCollection(10);
        }

        public override T Update(Dictionary<string, string> parameters)
        {
            return new T();
        }

        public override bool Destroy(T item)
        {
            return true;
        }
    }
}
