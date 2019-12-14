
using Reporting.DAL;
using Reporting.DAL.Concrete.EntityFramework;
using Reporting.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 



namespace Reporting.BLL
{
    public class Repository
    {
        ContextBoer1 _context = new ContextBoer1();


        EFRaporKriterleriDal raporKriterleriDal = new EFRaporKriterleriDal();

        public void RaporAcilisBilgiEkle(RAPOR_KRITERLERI_HIDIR entity)
        {

            raporKriterleriDal.Add(entity);


      

        }

        public List<RAPOR_KRITERLERI_HIDIR> TumHareketler()
        {

           return raporKriterleriDal.GetAll().ToList(); 

 

        }



        public IEnumerable<object> RaporTabloViewDinamikSorgula(string TabloveyaViewAdi)
        {

            RaporTabloViewDinamikSorgulaDAL DinamikSorgula = new DAL.RaporTabloViewDinamikSorgulaDAL();

            return DinamikSorgula.DirectQuery(TabloveyaViewAdi);
     

 

        }
        public List<BOER_RAPOR_VIEW_2019_DNM> RaporTabloViewDinamikSorgulaCiro(string TabloveyaViewAdi)
        {

            RaporTabloViewDinamikSorgulaDAL DinamikSorgula = new DAL.RaporTabloViewDinamikSorgulaDAL();

            return DinamikSorgula.DirectQueryListCiro(TabloveyaViewAdi);

 

        }

        public List<SATICI_ADET_MARKA_VIEW_HIDIR2> RaporTabloViewDinamikSorgulaSatis(string TabloveyaViewAdi)
        {

            RaporTabloViewDinamikSorgulaDAL DinamikSorgula = new DAL.RaporTabloViewDinamikSorgulaDAL();

            return DinamikSorgula.DirectQueryListSatis(TabloveyaViewAdi);


 
        }


   

        public IEnumerable<object> RaporTabloViewDinamikSorgulaSaticiMusteriTemsil(string TabloveyaViewAdi)
        {

            RaporTabloViewDinamikSorgulaDAL DinamikSorgula = new DAL.RaporTabloViewDinamikSorgulaDAL();

            return DinamikSorgula.DirectQueryListSaticiMusteri(TabloveyaViewAdi);

             

        }


        public List<SATICI_BAZ_AYRI_ILK20_VIEW_HIDIR> RaporTabloViewDinamikSorgulaSaticiBazAyri_ilk20(string TabloveyaViewAdi)
        {

            RaporTabloViewDinamikSorgulaDAL DinamikSorgula = new DAL.RaporTabloViewDinamikSorgulaDAL();

            return DinamikSorgula.RaporTabloViewDinamikSorgulaSaticiBazAyri_ilk20(TabloveyaViewAdi);


 

        }

        public List<MUSTERI_TEMS_SATICI_ILK20_VIEW_HIDIR> RaporTabloViewDinamikSorgulaMusteriTemsilSatici_ilk20(string TabloveyaViewAdi)
        {

            RaporTabloViewDinamikSorgulaDAL DinamikSorgula = new DAL.RaporTabloViewDinamikSorgulaDAL();

            return DinamikSorgula.RaporTabloViewDinamikSorgulaMusteriTemsilSatici_ilk20(TabloveyaViewAdi);


 

        }

        





    }
}
