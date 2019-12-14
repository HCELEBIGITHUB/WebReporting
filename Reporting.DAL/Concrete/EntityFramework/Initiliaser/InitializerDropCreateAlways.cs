using System.Data.Entity;

namespace Reporting.DAL.Concrete.EntityFramework.Initiliaser
{
    public class InitializerDropCreateAlways<T> : CreateDatabaseIfNotExists<T> where T : DbContext
    {
        protected override void Seed(T context)
        {
            base.Seed(context);
        }
    }
}
