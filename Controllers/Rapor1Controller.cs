using Reporting.Entities.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Reporting.MvcWebUI.Controllers
{
    public class Rapor1Controller : Controller
    {
        // GET: Rapor1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {

            RAPOR_KRITERLERI_HIDIR kriter = new RAPOR_KRITERLERI_HIDIR();
            kriter.ACIKLAMA = "deneme" + DateTime.Now.ToString();

            Reporting.BLL.Repository repo = new Reporting.BLL.Repository();
            repo.RaporAcilisBilgiEkle(kriter);

            List<RAPOR_KRITERLERI_HIDIR> tum_liste = repo.TumHareketler();

            // Reporting.DAL.RaporKriterleriDal raporKriterleriDal = new DAL.RaporKriterleriDal();

            //ViewData["kriter"] = kriter;
            // ViewBag.Kriter = kriter;

            return View(tum_liste);
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            return View();
        }
    }
}