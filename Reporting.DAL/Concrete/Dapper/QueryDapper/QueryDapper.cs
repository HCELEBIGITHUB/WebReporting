using Reporting.DAL.Abstract.Dapper;
using Reporting.Entities.Model;
using System.Collections.Generic;
using System.Linq;
namespace Reporting.DAL.Concrete.Dapper.QueryDapper
{
    public class GetAllRaporKriterleri : IQuery<IList<RAPOR_KRITERLERI_HIDIR>>
    {
        public IList<RAPOR_KRITERLERI_HIDIR> Execute(IConnection connection)
        {
            return connection.Query<RAPOR_KRITERLERI_HIDIR>("SELECT * FROM RAPOR_KRITERLERI_HIDIR order by ID asc").ToList();
        }
    }

    public class GetRaporKriterleriByACIKLAMA : IQuery<IList<RAPOR_KRITERLERI_HIDIR>>
    {
        private readonly string _aciklama;

        public GetRaporKriterleriByACIKLAMA(string aciklama)
        {
            _aciklama = aciklama;
        }

        public IList<RAPOR_KRITERLERI_HIDIR> Execute(IConnection connection)
        {
            return connection.Query<RAPOR_KRITERLERI_HIDIR>("SELECT * FROM RAPOR_KRITERLERI_HIDIR WHERE ACIKLAMA = @aciklama", new { aciklama = _aciklama }).ToList();
        }
    }
}
