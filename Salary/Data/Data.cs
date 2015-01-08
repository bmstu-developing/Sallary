using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salary.Domain;

namespace Salary.Data
{
    public class Data<T> : IRepository<T> where T: Entity
    {
        private readonly Dictionary<Guid, T> _map = new Dictionary<Guid, T>();

        public T Get(Guid id)
        {
            return _map.ContainsKey(id)
                ? _map[id]
                : default(T);
        }

        public void Add(T entity)
        {
            _map.Add(entity.Id, entity);
        }

        public IQueryable<T> AsQueryable()
        {
            return _map.Values.AsQueryable();
        }
    }
}
