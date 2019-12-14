using Dapper;
using System;
using System.Data.SqlClient;


namespace Reporting.DAL.Concrete.Dapper
{
    public class DapperCrudTransactionalDAL
    {

        //  protected void Create<TEntity>(TEntity modelOf) where TEntity : class, new()


        // public void UpdateInsertDeleteTransactional(T  modelOf, int widgetId, int quantity)
        public void UpdateInsertDeleteTransactional<TEntity>(TEntity _entity, int widgetId, int quantity) where TEntity : class, new()
        {
            using (var conn = new SqlConnection("{connection string}"))
            {
                conn.Open();

                // create the transaction
                // You could use `var` instead of `SqlTransaction`
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        var sql = "update Widget set Quantity = @quantity where WidgetId = @id";
                        var parameters = new { id = widgetId, quantity };

                        // pass the transaction along to the Query, Execute, or the related Async methods.
                        conn.Execute(sql, parameters, tran);

                        // if it was successful, commit the transaction
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        // roll the transaction back
                        tran.Rollback();

                        // handle the error however you need to.
                        throw new Exception("Transactional islemde hata olustu Hata Mesaj:" + ex.Message.ToString());
                    }
                }
            }
        }


    }


}
