using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reporting.DAL.Abstract
{
    public interface IRepositoryGeneric<T> where T : class
    {

        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);//Teoride ihtiyacımız yok fakat pratikte yararlı oluyor
        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);//Teoride ihtiyacımız yok fakat pratikte yararlı oluyor
    }
}


