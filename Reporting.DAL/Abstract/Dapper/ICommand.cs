namespace Reporting.DAL.Abstract.Dapper
{
    public interface ICommand
    {


        void Execute(IConnection connection);

    }
}
