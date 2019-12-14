using Reporting.Entities.Model;
using System.Configuration;
using System.Data.Entity;

namespace Reporting.DAL.Concrete.EntityFramework
{
    public class MessageContext : BaseContext
    {
        public MessageContext()
            : base("name=MessageContext")
        {

            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
            this.Database.CommandTimeout = 999999999;
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Relation bağlantısı kurma örneği
            // İlişkileri kuruyoruz one-to-many olarak.
            //modelBuilder.Entity<Message>()
            //   .HasRequired<User>(x => x.FromUser)
            //   .WithMany(x => x.FromUserMessages)
            //   .HasForeignKey(x => x.FromUserId)
            //   .WillCascadeOnDelete(false); ;

            //modelBuilder.Entity<Message>()
            //   .HasRequired<User>(x => x.ToUser)
            //    .WithMany(x => x.ToUserMessages)
            //   .HasForeignKey(x => x.ToUserId);

            //base.OnModelCreating(modelBuilder);
        }
    }

}




