using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitSaveChangesAsync();
        void CommitSaveChanges();
    }
}
