using System.Collections.Generic;
using System.Web.Mvc;

namespace Reporting.MvcWebUI.Controllers
{
    public class Rapor2Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {

            //rapor2

            Reporting.BLL.Repository repo = new Reporting.BLL.Repository();
            IEnumerable<object> sorgu_sonucu = repo.RaporTabloViewDinamikSorgula("[workcube_boer_2019_1].[dbo].[ACCOUNT_ACCOUNT_REMAINDER]");


            return View(sorgu_sonucu);
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            return View();
        }
    }
}