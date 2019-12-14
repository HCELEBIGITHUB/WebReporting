using Reporting.DAL.Abstract;
using Reporting.DAL.Concrete.EntityFramework;
using Reporting.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reporting.DAL
{

    public class EFRaporKriterleriDal : IRaporKriterleriDal
    {
        private ContextBoer1 _context = new ContextBoer1();


        //public EFRaporKriterleriDal(ContextBoer1 context_)
        //{

        //    _context = context_;


        //}




        public List<RAPOR_KRITERLERI_HIDIR> GetAll()
        {
            return _context.RAPOR_KRITERLERI_HIDIRs.ToList();
        }

        public RAPOR_KRITERLERI_HIDIR Get(int ID)
        {
            return _context.RAPOR_KRITERLERI_HIDIRs.Where(p => p.ID == ID).FirstOrDefault();
        }

        public void Add(RAPOR_KRITERLERI_HIDIR Kriter)
        {
            _context.RAPOR_KRITERLERI_HIDIRs.Add(Kriter);
            _context.SaveChanges();
        }

        public void Delete(int ID)
        {
            _context.RAPOR_KRITERLERI_HIDIRs.Remove(_context.RAPOR_KRITERLERI_HIDIRs.Where(p => p.ID == ID).FirstOrDefault());
            _context.SaveChanges();
        }




        public void Update(RAPOR_KRITERLERI_HIDIR kriter)
        {
            RAPOR_KRITERLERI_HIDIR kriter_update = _context.RAPOR_KRITERLERI_HIDIRs.Where(p => p.ID == kriter.ID).FirstOrDefault();

            kriter_update.ACIKLAMA = kriter.ACIKLAMA;
            _context.SaveChanges();
        }

        List<RAPOR_KRITERLERI_HIDIR> IRaporKriterleriDal.GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
