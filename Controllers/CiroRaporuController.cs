using Reporting.Entities.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Reporting.MvcWebUI.Controllers
{
    public class CiroRaporuController : Controller
    {
        // GET: CiroRaporu

        List<BOER_RAPOR_VIEW_2019_DNM> ciro;
        public ActionResult CiroRaporu()
        {
            //** RaporVerileri();

            //ViewData["Ciro"] = GetTeachers();
            Reporting.BLL.Repository _repo = new Reporting.BLL.Repository();
            ViewData["SatisAdetMarka"] = _repo.RaporTabloViewDinamikSorgulaSatis("[workcube_boer_1].[dbo].[SATICI_ADET_MARKA_VIEW_HIDIR2]");
            return View(ciro);

        }

        public JsonResult RaporVerileri()
        {



            Reporting.BLL.Repository _repo = new Reporting.BLL.Repository();

            var _resultquery = _repo.RaporTabloViewDinamikSorgulaCiro("[workcube_boer_1].[dbo].[BOER_RAPOR_VIEW_2019_DNM]");
            List<BOER_RAPOR_VIEW_2019_DNM> _result = _resultquery.ToList();
            ciro = _result;
            return Json(_result, JsonRequestBehavior.AllowGet);



        }
    }


}