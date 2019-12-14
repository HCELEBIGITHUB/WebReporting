using Reporting.DAL.Abstract.Dapper;
namespace Reporting.DAL.Concrete.Dapper
{
    public class ContextBaseDapper : IContext
    {

        private DapperConnection _connection { get; set; }

        public ContextBaseDapper(DapperConnection connection)
        {
            _connection = connection;
        }

        public T Query<T>(IQuery<T> query)
        {
            var result = query.Execute(_connection);
            return result;
        }

        public void Execute(ICommand command)
        {
            command.Execute(_connection);
        }

        public void CommitManuel()
        {
            _connection.CommitManuel();
        }
    }
}


