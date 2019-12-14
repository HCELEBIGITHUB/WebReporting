using System;
using System.Data;

namespace Reporting.DAL.Abstract.Dapper
{
    public interface IUnitOfWorkDapper : IDisposable
    {
        IDbConnection Connection { get; }
        T Transaction<T>(Func<IDbTransaction, T> query);
        IDbTransaction BeginTransaction();
        void CommitManuel();

    }
}


