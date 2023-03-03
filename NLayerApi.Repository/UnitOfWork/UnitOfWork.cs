using NLayerApi.Core.UnitOfWork;
using NLayerApi.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Repository.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void CommitSaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task CommitSaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
