using Reporting.DAL.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Entities.Model;

namespace Reporting.BLL
{
    public class CallDapperCQRSoperationsService
    {

        DapperOperations oprs = new DapperOperations();
        public CallDapperCQRSoperationsService()
        {
           

        }
        public IEnumerable<RAPOR_KRITERLERI_HIDIR> GetAllRaporKriterleri()
        {

           return  oprs.GetAllRaporKriterleri();

        }
        public IEnumerable<RAPOR_KRITERLERI_HIDIR> GetRaporKriterleriByACIKLAMA(string aciklama)
        {

            return oprs.GetRaporKriterleriByACIKLAMA(aciklama);

        }
        public void  SaveRaporKriterleri(RAPOR_KRITERLERI_HIDIR yeniKriter)
        {

               oprs.SaveRaporKriterleri(yeniKriter);

        }

        public void CommitManuel()
        {

            oprs.CommitManuel();
        }








    }
}
