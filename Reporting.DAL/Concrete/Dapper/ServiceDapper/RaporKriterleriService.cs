using Reporting.DAL.Abstract.Dapper;
using Reporting.DAL.Concrete.Dapper.CommandDapper;
using Reporting.DAL.Concrete.Dapper.QueryDapper;
using Reporting.Entities.Model;
using System;
using System.Collections.Generic;

namespace Reporting.DAL.Concrete.Dapper.ServiceDapper
{
    public class RaporKriterleriService : AbstRaporKriterleriService
    {

        protected readonly IContext _context;

        public RaporKriterleriService(IContext context)
        {
            _context = context;


        }



        public override void DeleteRaporKriterleri()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<RAPOR_KRITERLERI_HIDIR> GetAllRaporKriterleri()
        {
            return _context.Query(new GetAllRaporKriterleri());
        }

        public override IEnumerable<RAPOR_KRITERLERI_HIDIR> GetRaporKriterleriByACIKLAMA(string aciklama)
        {
            return _context.Query(new GetRaporKriterleriByACIKLAMA(aciklama));
        }

        public override void SaveRaporKriterleri(RAPOR_KRITERLERI_HIDIR RaporKriterleri)
        {
            _context.Execute(new SaveRaporKriterleri(RaporKriterleri));



        }
        public override void CommitManuel()
        {
            _context.CommitManuel();
        }



    }
}



