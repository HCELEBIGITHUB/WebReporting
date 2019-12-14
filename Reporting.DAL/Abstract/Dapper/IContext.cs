
namespace Reporting.DAL.Abstract.Dapper
{

    public interface IContext
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
        void CommitManuel();
    }

}
