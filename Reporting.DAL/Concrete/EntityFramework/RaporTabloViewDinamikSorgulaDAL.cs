using Reporting.DAL.Concrete.EntityFramework;
using Reporting.Entities.Model;
using System.Collections.Generic;
using System.Linq;
namespace Reporting.DAL
{
    public class RaporTabloViewDinamikSorgulaDAL
    {

        private ContextBoer1 _context = new ContextBoer1();


        public IEnumerable<object> DirectQuery(string TabloveyaViewAdi)
        {
            // using (var context = new SampleContext())

            bool kolonAdlariYazildi = false;
            List<object> sonuc = new List<object>();
            List<object> columns_name = new List<object>();
            string sql = "";

            using (var command = _context.Database.Connection.CreateCommand())
            {
                sql = "";
                // kolon basliklari icin union

                sql += "SELECT * From " + TabloveyaViewAdi;

                command.CommandText = sql;

                _context.Database.Connection.Open();
                var result = command.ExecuteReader();

                // kolon adlari
                for (int i = 0; i < result.FieldCount; i++)
                {
                    columns_name.Add(result.GetName(i));
                }

                //***** sonuc.Add(columns_name);

                foreach (var item in result)
                {


                    sonuc.Add(item);



                }
                _context.Database.Connection.Close();
                _context.Database.Connection.Dispose();
                return sonuc;

                //using (var result = command.ExecuteReader())
                // {
                //     return (IEnumerable<object>)result;
                // }
            }
        }




        public List<BOER_RAPOR_VIEW_2019_DNM> DirectQueryListCiro(string TabloveyaViewAdi)
        {


            string sqlQuery = " select * from  " + TabloveyaViewAdi;



            var resultCiro = _context.Database.SqlQuery<BOER_RAPOR_VIEW_2019_DNM>(sqlQuery).ToList<BOER_RAPOR_VIEW_2019_DNM>();

            return resultCiro;


        }

        public List<SATICI_ADET_MARKA_VIEW_HIDIR2> DirectQueryListSatis(string TabloveyaViewAdi)
        {


            string sqlQuery = " select  distinct * from  " + TabloveyaViewAdi;
            sqlQuery += " order by  SATICIKODU   ";

            var resultCiro = _context.Database.SqlQuery<SATICI_ADET_MARKA_VIEW_HIDIR2>(sqlQuery).ToList<SATICI_ADET_MARKA_VIEW_HIDIR2>();

            return resultCiro;


        }
        public List<SATC_MUST_VIEW_HIDIR> DirectQueryListSaticiMusteri(string TabloveyaViewAdi)
        {


            string sqlQuery = " select  distinct * from  " + TabloveyaViewAdi;
            sqlQuery += "  ORDER BY  SIRA,YIL_TUTAR_SIRALAMA DESC  ,SATICIKODU,FirmaUNVAN   ";


            var resultCiro = _context.Database.SqlQuery<SATC_MUST_VIEW_HIDIR>(sqlQuery).ToList<SATC_MUST_VIEW_HIDIR>();




            //_context.Database.SqlQuery(sqlQuery) as IEnumerable<IDictionary<string, object>> ;

            return resultCiro;


        }
        public List<SATICI_BAZ_AYRI_ILK20_VIEW_HIDIR> RaporTabloViewDinamikSorgulaSaticiBazAyri_ilk20(string TabloveyaViewAdi)
        {


            string sqlQuery = " select  distinct * from  " + TabloveyaViewAdi;
            sqlQuery += "  ORDER BY  SATICIKODU,SIRA     ";


            var resultCiro = _context.Database.SqlQuery<SATICI_BAZ_AYRI_ILK20_VIEW_HIDIR>(sqlQuery).ToList<SATICI_BAZ_AYRI_ILK20_VIEW_HIDIR>();




            //_context.Database.SqlQuery(sqlQuery) as IEnumerable<IDictionary<string, object>> ;

            return resultCiro;


        }

        public List<MUSTERI_TEMS_SATICI_ILK20_VIEW_HIDIR> RaporTabloViewDinamikSorgulaMusteriTemsilSatici_ilk20(string TabloveyaViewAdi)
        {


            string sqlQuery = " select  distinct * from  " + TabloveyaViewAdi;
            sqlQuery += "  ORDER BY MusteriTemsilcisi,FirmaKODU, SATICIKODU,SIRA     ";


            var resultCiro = _context.Database.SqlQuery<MUSTERI_TEMS_SATICI_ILK20_VIEW_HIDIR>(sqlQuery).ToList<MUSTERI_TEMS_SATICI_ILK20_VIEW_HIDIR>();




            //_context.Database.SqlQuery(sqlQuery) as IEnumerable<IDictionary<string, object>> ;

            return resultCiro;


        }





    }





}
