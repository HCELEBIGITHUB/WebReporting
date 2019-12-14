using Reporting.DAL.Abstract.Dapper;
using Reporting.DAL.Concrete.Dapper.ServiceDapper;
using Reporting.Entities.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
namespace Reporting.DAL.Concrete.Dapper
{


    public class DapperOperations
    {
        private IContext context;
        //*private IConnection connection;
        private DapperConnection connection;
        // private AbsSuppliersService service;
        private AbstRaporKriterleriService service;


        //private string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\App_Data\Suppliers.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        public DapperOperations()
        {
            connection = new DapperConnection(connectionString);
            context = new ContextBaseDapper(connection);
            //service = new SupplierService(context);

            service = new RaporKriterleriService(context);



        }

        public IEnumerable<RAPOR_KRITERLERI_HIDIR> GetAllRaporKriterleri()
        {
            IEnumerable<RAPOR_KRITERLERI_HIDIR> raporKriterleri = service.GetAllRaporKriterleri();
            /// DisplayRaporKriterleri(raporKriterleri);
            return raporKriterleri;
        }

        public IEnumerable<RAPOR_KRITERLERI_HIDIR> GetRaporKriterleriByACIKLAMA(string aciklama)
        {
            IEnumerable<RAPOR_KRITERLERI_HIDIR> raporKriterleri = service.GetRaporKriterleriByACIKLAMA(aciklama);
            // DisplayRaporKriterleri(raporKriterleri);
            return raporKriterleri;
        }

        public void SaveRaporKriterleri(RAPOR_KRITERLERI_HIDIR raporKriterleri)
        {


            service.SaveRaporKriterleri(raporKriterleri);

        }

        public void DeleteRaporKriterleri()
        {
            service.DeleteRaporKriterleri();

        }

        private void DisplayRaporKriterleri(IEnumerable<RAPOR_KRITERLERI_HIDIR> raporKriterleri)
        {
            foreach (var Kriter in raporKriterleri)
            {
                Console.WriteLine($"Id {Kriter.USER_ID} ACIKLAMA: {Kriter.ACIKLAMA}");
            }
        }



        public void CommitManuel()
        {

            connection.CommitManuel();
        }


        private void DisplayLine()
        {
            Console.WriteLine($"-----------------------------------");
        }

        private void Wait()
        {
            Console.ReadLine();
        }
    }

}
