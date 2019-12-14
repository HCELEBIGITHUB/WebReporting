using System.Data.Entity;

namespace Reporting.DAL.Concrete.EntityFramework.Initiliaser
{
    public class InitializerIfNotExists<T> : CreateDatabaseIfNotExists<T> where T : DbContext
    {
        protected override void Seed(T context)
        {
            base.Seed(context);
        }
    }
}





