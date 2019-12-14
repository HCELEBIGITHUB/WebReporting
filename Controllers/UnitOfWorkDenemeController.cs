using Reporting.BLL;
using System.Web.Mvc;

namespace Reporting.MvcWebUI.Controllers
{
    public class UnitOfWorkDenemeController : Controller
    {
        // GET: UnitOfWorkDeneme
        public ActionResult UnitOfWorkDeneme()
        {


            CallRepositoryUnitOfWork create_msg = new CallRepositoryUnitOfWork();
            create_msg.CallRepositoryUnitOfWorkCreateMessage();

            return View();
        }
    }
}