using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace AsyncEverythingWpf
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Task> _requests =
            new ObservableCollection<Task>();

        public ObservableCollection<Task> Requests { get { return _requests; } }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null) { return; }
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
