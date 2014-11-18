using System;
using System.Collections.ObjectModel;
using Api;

namespace WpfApplication
{
    public class MainVM : ViewModel
    {
        private readonly ObservableCollection<Thing> _things =
            new ObservableCollection<Thing>();

        [Obsolete]
        public ObservableCollection<Thing> Things { get { return _things; } }

        private readonly ObservableCollection<ThingVM> _thingVMs =
            new ObservableCollection<ThingVM>();

        public ObservableCollection<ThingVM> ThingVMs { get { return _thingVMs; } }

        public void Add(ThingVM item)
        {
            ThingVMs.Add(item);
            item.MainVM = this;
        }

        public void Remove(ThingVM item)
        {
            ThingVMs.Remove(item);
            if (item.MainVM == this)
            {
                item.MainVM = null;
            }
        }
    }
}
