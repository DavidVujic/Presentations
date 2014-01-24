using System.Collections.Generic;
using System.Web.Mvc;

namespace WebbProjektet.Controllers
{
    public class SearchController : Controller
    {
        public JsonResult Index(string q)
        {
            var data = new List<string> {"hello", "hello world"};

            return Json(new {data}, JsonRequestBehavior.AllowGet);
        }

    }
}
