using Reporting.DAL.Abstract;
using Reporting.DAL.Concrete.EntityFramework;
using Reporting.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Reporting.DAL.Concrete.Dapper
{


    public class RaporKriterleri_Dapper_DAL : IRaporKriterleriDal
    {
        public void Add(RAPOR_KRITERLERI_HIDIR firma)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public RAPOR_KRITERLERI_HIDIR Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<RAPOR_KRITERLERI_HIDIR> GetAll()
        {
            //**ConnectionRepository Con = new ConnectionRepository();



            //using (var conn = Con.GetOpenConnection())
            //{

            // return conn.Query<RAPOR_KRITERLERI_HIDIR>("Select * From RAPOR_KRITERLERI_HIDIR ").ToList();
            //}

            return null;


        }

        public DbContext SetDbContext(ContextBoer1 context_)
        {
            throw new NotImplementedException();
        }

        public void Update(RAPOR_KRITERLERI_HIDIR firma)
        {
            throw new NotImplementedException();
        }
    }
}
