using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfApplication
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Task> _requests =
            new ObservableCollection<Task>();

        public ObservableCollection<Task> Requests { get { return _requests; } }

        private DateTime __timestamp = DateTime.Now;

        public DateTime _Timestamp
        {
            get { return __timestamp; }
            set
            {
                if (__timestamp == value) { return; }

                __timestamp = value;
                OnPropertyChanged("_Timestamp");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null) { return; }
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void Add(Task item)
        {
            _requests.Add(item);
        }

        public bool Remove(Task item)
        {
            return _requests.Remove(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
