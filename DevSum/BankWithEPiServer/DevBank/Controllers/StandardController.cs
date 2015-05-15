using System.Web.Mvc;
using EPiServer.Web.Mvc;
using DevBank.Business.ServiceFactories;
using DevBank.Models.Pages;
using DevBank.Models.ViewModels;

namespace DevBank.Controllers
{
	public class StandardController : PageController<StandardPage>
	{
		private readonly CustomerService.IService _service;

		public StandardController(ICustomerFactory factory)
		{
			_service = factory.GetService();
		}

		public ActionResult Index(StandardPage currentPage)
		{
			return View(currentPage);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Send(StandardPage currentPage, UserModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			var customer = _service.GetCustomerBy(model.SocialSecurityNumber);

			ViewBag.Customer = customer;

			return View("Index", currentPage);
		}
	}
}