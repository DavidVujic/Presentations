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
			var model = new PageViewModel<StandardPage>(currentPage);

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Send(StandardPage currentPage, UserModel user)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			var customer = _service.GetCustomerBy(user.SocialSecurityNumber);

			var model = new PageViewModel<StandardPage>(currentPage, customer);

			if (Request.IsAjaxRequest())
			{
				return Json(model.ToJson());
			}

			return View("Index", model);
		}
	}
}