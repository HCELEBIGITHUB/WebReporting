using System.Collections.Generic;

namespace Reporting.DAL.Abstract.Dapper
{
    public interface IConnection
    {

        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string query, object param = null);
    }
}





