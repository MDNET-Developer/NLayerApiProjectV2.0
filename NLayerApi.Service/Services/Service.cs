using Microsoft.EntityFrameworkCore;
using NLayerApi.Core.Repositories;
using NLayerApi.Core.Service;
using NLayerApi.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Service.Services
{
    public class Service<T> : IService<T> where T : class, new()
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _uow;

        public Service(IGenericRepository<T> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _uow.CommitSaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity)
        {
            await _repository.AddRangeAsync(entity);
            await _uow.CommitSaveChangesAsync();
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async void Remove(T entity)
        {
            _repository.Remove(entity);
            await _uow.CommitSaveChangesAsync();
        }

        public async void RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRangeAsync(entities);
            await _uow.CommitSaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _repository.Update(entity);
            await _uow.CommitSaveChangesAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
