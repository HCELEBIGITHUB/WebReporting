﻿using Reporting.DAL.Abstract;
using System;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

namespace Reporting.DAL.Concrete.EntityFramework
{

    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly BaseContext _dbContext;

        public EFUnitOfWork(BaseContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException($"{nameof(dbContext)} can not be null");

            _dbContext = dbContext;
        }

        public IRepositoryGeneric<T> GetRepository<T>() where T : class
        {
            return new EFRepositoryGeneric<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (OptimisticConcurrencyException ex)
            {
                //TODO : handle exceptions
                throw;
                //var context = ((IObjectContextAdapter)_dbContext  ).ObjectContext;
                //// Resolve the concurrency conflict by refreshing the
                //// object context before re-saving changes.
                //context.Refresh(RefreshMode.ClientWins, orders);

                //// Save changes.
                //context.SaveChanges();
                //Console.WriteLine("OptimisticConcurrencyException "
                //+ "handled and changes saved");
            }
            catch (CommitFailedException ex)
            {
                //TODO : handle exceptions
                return _dbContext.SaveChanges();
            }
            catch (EntityException ex)
            {
                //TODO : handle exceptions
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO : handle exceptions
                throw;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
