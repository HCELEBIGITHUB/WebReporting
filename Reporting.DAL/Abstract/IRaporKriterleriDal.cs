using Reporting.Entities.Model;
using System.Collections.Generic;


namespace Reporting.DAL.Abstract
{
    public interface IRaporKriterleriDal
    {





        List<RAPOR_KRITERLERI_HIDIR> GetAll();
        RAPOR_KRITERLERI_HIDIR Get(int Id);
        void Add(RAPOR_KRITERLERI_HIDIR firma);
        void Delete(int Id);
        void Update(RAPOR_KRITERLERI_HIDIR firma);
    }
}
