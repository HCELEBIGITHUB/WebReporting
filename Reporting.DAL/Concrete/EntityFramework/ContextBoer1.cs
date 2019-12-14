namespace Reporting.DAL.Concrete.EntityFramework
{
    using Reporting.Entities.Model;
    using System.Configuration;
    using System.Data.Entity;

    public partial class ContextBoer1 : DbContext
    {
        public ContextBoer1()
            : base("name=DBContext")
        {

            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            this.Database.CommandTimeout = 999999999;

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public DbSet<RAPOR_KRITERLERI_HIDIR> RAPOR_KRITERLERI_HIDIRs { get; set; }
        public virtual DbSet<BOER_RAPOR_VIEW_2019_DNM> BOER_RAPOR_VIEW_2019_DNM { get; set; }

    }
}
