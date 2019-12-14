using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Reporting.Entities.Model;
using System.Net.Http;
using System.Web.Http;

namespace Reporting.MvcWebUI.Controllers
{
    public class PivotGridDataController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {


            using (var httpClient = new HttpClient())
            {
                var json = httpClient.GetStringAsync("http://localhost:29797/api/web");

                // Now parse with JSON.Net
            }


            return Request.CreateResponse(DataSourceLoader.Load(SampleData.Sales, loadOptions));
        }
    }
}