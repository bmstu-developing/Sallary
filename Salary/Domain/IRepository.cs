using System;
using System.Linq;

namespace Salary.Domain
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid id);
        void Add(T entity);
        IQueryable<T> AsQueryable();
    }
}
