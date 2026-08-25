using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly BipassDbContext _dbContext;
         public BaseRepository(BipassDbContext bipassdbContext)
        {
            _dbContext = bipassdbContext;
        }

        public List<T> Get()
        {
          return _dbContext.Set<T>().ToList();
        }
        public T Get<TId> (TId id)
        {
            return _dbContext.Set<T>().Find(new object[] {id});
        }
    }
}
