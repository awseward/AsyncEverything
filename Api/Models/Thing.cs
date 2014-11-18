using System;
using Utilities;

namespace Api
{
    public class Thing
    {
        public Thing()
        {
            var newerOld = OldDatesHelper.GetPastDateTime();
            var olderOld = OldDatesHelper.GetPastDateTime(newerOld);

            UpdatedAt = newerOld;
            CreatedAt = olderOld;
        }

        private Guid _guid = Guid.NewGuid();

        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private DateTime? _createdAt;

        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

        private DateTime? _updatedAt;

        public DateTime? UpdatedAt
        {
            get { return _updatedAt; }
            set { _updatedAt = value; }
        }
    }
}
