using System.Web.Mvc;
using NoScriptFirst.Models;
using NoScriptFirst.Services;

namespace NoScriptFirst.Controllers
{
    public class HomeController : Controller
    {
	    private readonly MyLittleService _service;

	    public HomeController()
	    {
		    _service = new MyLittleService();
	    }
	    
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
	    public ActionResult Add(Person person)
		{
			var isValid = ModelState.IsValid;

		    _service.AddToDatabase(person.FullName, person.Age);

			if (Request.IsAjaxRequest())
			{
				return Json("ok", JsonRequestBehavior.DenyGet);
			}

		    return View();
	    }
	}
}