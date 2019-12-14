using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Reporting.DAL.Concrete.EntityFramework
{
    public class BaseContext : DbContext
    {

        public BaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            this.Database.CommandTimeout = 999999999;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }

    }
}



