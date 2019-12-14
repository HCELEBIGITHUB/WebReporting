using System;

namespace Reporting.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryGeneric<T> GetRepository<T>() where T : class;
        int SaveChanges();

    }
}

