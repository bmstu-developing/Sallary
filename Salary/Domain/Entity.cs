using System;

namespace Salary.Domain
{
    public abstract class Entity
    {
        private readonly Guid _id;

        protected Entity()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id
        {
            get { return _id; }
        }
    }
}
