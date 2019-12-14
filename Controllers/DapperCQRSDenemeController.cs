using Reporting.BLL;
using Reporting.Entities.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Reporting.MvcWebUI.Controllers
{
    public class DapperCQRSDenemeController : Controller
    {
        // GET: UnitOfWorkDeneme
        public ActionResult DapperCQRSDeneme()//  dapper CQRS  command larin ayri  query lerin ayri olmasi
        {

            CallDapperCQRSoperationsService DapperOprsService = new CallDapperCQRSoperationsService();

            IEnumerable<RAPOR_KRITERLERI_HIDIR> kriterler = DapperOprsService.GetAllRaporKriterleri();


            foreach (var kriter in kriterler)
            {

                //  Console.WriteLine(msg.ToString());
                System.Diagnostics.Debug.WriteLine(kriter.ACIKLAMA.ToString());
                Response.Write(kriter.ACIKLAMA.ToString());

                // HttpContext.Current.Response.Write(kriter.ACIKLAMA.ToString());

            }


            IEnumerable<RAPOR_KRITERLERI_HIDIR> kriterlerAciklama = DapperOprsService.GetRaporKriterleriByACIKLAMA("DENEMEACIKLAMA3");



            RAPOR_KRITERLERI_HIDIR yeniKriter = new RAPOR_KRITERLERI_HIDIR { ACIKLAMA = "deneme" + new Random().Next(1, 1000), USER_ID = new Random().Next(1, 1000).ToString() };




            DapperOprsService.SaveRaporKriterleri(yeniKriter);

            ////**  DapperOprsService.CommitManuel();  her islem icin transaction baslattigi icin manuel commit calismiyor..

            // DapperOprsService.SaveSupplier(yeniKriter);



            //CallRepositoryUnitOfWork create_msg = new CallRepositoryUnitOfWork();
            //create_msg.CallRepositoryUnitOfWorkCreateMessage();
            //Dapper

            //SampleDapperApp app = new SampleDapperApp();
            //app.DeleteSuppliers();
            //app.DisplayLine();
            //app.SaveSuppliers();
            //app.DisplayLine();
            //app.GetSuppliers();
            //app.DisplayLine();
            //app.GetSuppliersByCountry();
            //app.DisplayLine();
            //app.SaveSuppliers();
            //app.DisplayLine();
            //app.GetSuppliers();
            //app.DisplayLine();
            //app.Wait();



            return View();
        }
    }
}