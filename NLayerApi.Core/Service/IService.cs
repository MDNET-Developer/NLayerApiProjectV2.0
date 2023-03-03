using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Core.Service
{
    public interface IService<T> where T : class, new()
    {
        Task<T> GetById(int id);
        //IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        //Elave etdikdikden sonra geriye entity dondermek istediyimiz ucun Task<T> yaziriq.Ancaq servis ucun geriye entitiy donderirik 
        Task<T> AddAsync(T entity);
        //Elave etdikdikden sonra geriye entity dondermek istediyimiz ucun Task<IEnumerable<T>> yaziriq
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRangeAsync(IEnumerable<T> entities);
    }
}
