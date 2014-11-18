using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Api
{
    public class BrokenClient<T> : Client<T>
        where T : new()
    {
        public override T Show()
        {
            throw Network.GetRandomWebException();
        }

        public override IEnumerable<T> Index()
        {
            throw Network.GetRandomWebException();
        }

        public override bool Destroy(T item)
        {
            throw Network.GetRandomWebException();
        }
    }
}
