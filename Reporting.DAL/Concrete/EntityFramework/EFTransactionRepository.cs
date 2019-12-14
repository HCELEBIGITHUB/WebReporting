using Reporting.DAL.Abstract;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Reporting.DAL.Concrete.EntityFramework
{
    public class EFTransactionRepository<T> : IRepositoryGeneric<T> where T : class
    {

        private readonly BaseContext _dbContext;
        private readonly IRepositoryGeneric<T> repository;
        private IsolationLevel isolationLevel = IsolationLevel.Serializable;

        public IsolationLevel IsolationLevel
        {
            get
            {
                return isolationLevel;
            }

            set
            {
                isolationLevel = value;
            }
        }

        public EFTransactionRepository(BaseContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException($"{nameof(dbContext)} can not be null");

            _dbContext = dbContext;
            repository = new EFRepositoryGeneric<T>(_dbContext);
        }

        public IQueryable<T> GetAll()
        {
            return RunWithTransaction<IQueryable<T>>(() => { return repository.GetAll(); });
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return RunWithTransaction<IQueryable<T>>(() => { return repository.GetAll(predicate); });

        }

        public T GetById(int id)

        {
            return RunWithTransaction<T>(() => { return repository.GetById(id); });
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return RunWithTransaction<T>(() => { return repository.Get(predicate); });
        }

        public void Add(T entity)
        {
            RunWithTransaction(() => { repository.Add(entity); });
        }

        public void Delete(int id)
        {
            RunWithTransaction(() => { repository.Delete(id); });
        }

        public void Delete(T entity)
        {
            RunWithTransaction(() => { repository.Delete(entity); });
        }

        public void Update(T entity)
        {
            RunWithTransaction(() => { repository.Update(entity); });
        }
        public K RunWithTransaction<K>(Func<K> func)
        {
            using (_dbContext.Database.BeginTransaction(IsolationLevel))
            {
                return func();
            }
        }

        public void RunWithTransaction(Action func)
        {
            using (_dbContext.Database.BeginTransaction(IsolationLevel))
            {
                func();
            }
        }
    }
}







