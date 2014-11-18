using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api;

namespace WpfApplication
{
    public class ThingVM : ViewModel
    {
        public ThingVM(Thing thing)
        {
            UpdateFields(thing);
        }

        private Guid _guid;

        public Guid Guid
        {
            get { return _guid; }
            set
            {
                if (_guid == value) { return; }

                _guid = value;
                OnPropertyChanged("Guid");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) { return; }

                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private DateTime? _createdAt;

        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set
            {
                if (_createdAt == value) { return; }

                _createdAt = value;
                OnPropertyChanged("CreatedAt");
            }
        }

        private DateTime? _updatedAt;

        public DateTime? UpdatedAt
        {
            get { return _updatedAt; }
            set
            {
                if (_updatedAt == value) { return; }

                _updatedAt = value;
                OnPropertyChanged("UpdatedAt");
            }
        }

        private MainVM _mainVM;

        public MainVM MainVM
        {
            get { return _mainVM; }
            set
            {
                if (_mainVM == value) { return; }

                _mainVM = value;
                OnPropertyChanged("MainVM");
            }
        }

        private void UpdateFields(Thing thing)
        {
            Guid = thing.Guid;
            Name = thing.Name;
            CreatedAt = thing.CreatedAt;
            UpdatedAt = thing.UpdatedAt;
            _Timestamp = DateTime.Now;
        }

        // Ehh......
        public Thing ToThing()
        {
            return new Thing
            {
                Guid = this.Guid,
                Name = this.Name,
                CreatedAt = this.CreatedAt,
                UpdatedAt = this.UpdatedAt
            };
        }
    }
}
