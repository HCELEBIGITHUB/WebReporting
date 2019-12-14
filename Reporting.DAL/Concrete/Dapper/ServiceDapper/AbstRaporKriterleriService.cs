using Reporting.Entities.Model;
using System.Collections.Generic;
using System.ServiceProcess;

namespace Reporting.DAL.Concrete.Dapper.ServiceDapper
{
    public abstract class AbstRaporKriterleriService : ServiceBase
    {



        public abstract IEnumerable<RAPOR_KRITERLERI_HIDIR> GetAllRaporKriterleri();
        public abstract IEnumerable<RAPOR_KRITERLERI_HIDIR> GetRaporKriterleriByACIKLAMA(string aciklama);
        public abstract void SaveRaporKriterleri(RAPOR_KRITERLERI_HIDIR RaporKriterleri);
        public abstract void DeleteRaporKriterleri();
        public abstract void CommitManuel();


    }
}




