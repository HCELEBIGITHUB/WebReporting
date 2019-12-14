namespace Reporting.DAL.Abstract.Dapper
{
    public interface IQuery<out T>
    {
        T Execute(IConnection connection);
    }

}


