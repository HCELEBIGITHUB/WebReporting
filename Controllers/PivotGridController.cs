using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Reporting.MvcWebUI.Controllers
{
    public class PivotGridController : Controller
    {
        public ActionResult Overview()
        {

            //var controller = new ProductsController(repository);

            var controller = new PivotGridDataController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            // var response = controller.Get(DataSourceLoadOptions);


            return View();
        }

        public JsonResult RaporVerileri()
        {
            //Entities.Model.SampleData.
            // JsonResult _result = Json(Reporting.Entities.Model.SampleData.Sales, JsonRequestBehavior.AllowGet);
            JsonResult _result = Json(Reporting.Entities.Model.SampleData.Sales, JsonRequestBehavior.AllowGet);




            return _result;
        }
    }
}