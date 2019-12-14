using Reporting.DAL.Abstract.Dapper;
using Reporting.Entities.Model;
namespace Reporting.DAL.Concrete.Dapper.CommandDapper
{
    public class DeleteRaporKriterleri : ICommand
    {
        private readonly RAPOR_KRITERLERI_HIDIR _raporKriterleri;


        public DeleteRaporKriterleri(RAPOR_KRITERLERI_HIDIR raporKriterleri)
        {
            _raporKriterleri = raporKriterleri;
        }
        public void Execute(IConnection connection)
        {
            connection.Execute("DELETE FROM RAPOR_KRITERLERI_HIDIR k where k.ID=@ID ", new { _raporKriterleri.ID });

        }
    }
}


