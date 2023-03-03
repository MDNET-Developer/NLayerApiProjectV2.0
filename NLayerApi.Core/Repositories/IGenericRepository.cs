using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Core.Repositories
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        /*Where(x=>x.Id == 5) burada "x=>" olan hisse TEntity hissesine uygun gelir, "x.Id==5" olan hisse ise bool tipine uygun gelir ki, bu sorguda 5-e beraberdir ya yox ? sorgusu gedir
         * 
        Biz ne zaman ToList() desek o zaman sorgunu yerine yetirir*/
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRangeAsync(IEnumerable<T> entity);
    }
}
