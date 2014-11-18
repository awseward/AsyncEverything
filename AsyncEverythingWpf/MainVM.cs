using System.Collections.ObjectModel;
using Api;

namespace AsyncEverythingWpf
{
    public class MainVM : ViewModel
    {
        private readonly ObservableCollection<Thing> _things =
            new ObservableCollection<Thing>();

        public ObservableCollection<Thing> Things { get { return _things; } }
    }
}
