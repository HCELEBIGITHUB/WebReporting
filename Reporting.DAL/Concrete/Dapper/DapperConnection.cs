using Dapper;
using Reporting.DAL.Abstract.Dapper;
using System.Collections.Generic;

namespace Reporting.DAL.Concrete.Dapper
{
    public class DapperConnection : IConnection
    {
        private readonly IUnitOfWorkDapper _context;

        public DapperConnection(string connectionString)
        {
            _context = new DapperUnitOfWork(connectionString);

        }

        public DapperConnection(DapperUnitOfWork context)
        {
            _context = context;



        }



        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            return _context.Transaction(transaction =>
            {
                var result = _context.Connection.Query<T>(query, param, transaction);
                return result;
            });

        }

        public void Execute(string sql, object param)
        {
            _context.Transaction(transaction => _context.Connection.Execute(sql, param, transaction));

        }
        public void CommitManuel()
        {

            _context.CommitManuel();
        }

    }
}




