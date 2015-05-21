using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DevBank.Business.ServiceFactories;
using DevBank.Controllers;
using DevBank.CustomerService;
using DevBank.CustomerService.Entities;
using DevBank.Models.Pages;
using DevBank.Models.ViewModels;
using Moq;
using NUnit.Framework;

namespace DevBank.Tests
{
	[TestFixture]
	public class StandardControllerTests
	{
		private Mock<IService> _service;
		private Mock<ICustomerFactory> _factory;

		private StandardController _controller;
		private StandardPage _page;
		private UserModel _userModel;

		private const string SocialSecurityNumber = "191010101010";

		[SetUp]
		public void Setup()
		{
			_service = new Mock<IService>();
			_factory = new Mock<ICustomerFactory>();

			_factory
				.Setup(f => f.GetService())
				.Returns(_service.Object);

			_service
				.Setup(s => s.GetCustomerBy(SocialSecurityNumber))
				.Returns(new LocalCustomer());

			_controller = new StandardController(_factory.Object);

			_page = new StandardPage();
			_userModel = new UserModel {SocialSecurityNumber = SocialSecurityNumber};
		}

		[Test]
		public void Should_return_view_model()
		{
			var result = _controller.Index(_page) as ViewResult;

			Assert.IsNotNull(result);
			Assert.True(result.Model is PageViewModel<StandardPage>);
		}

		[Test]
		public void Should_call_customer_service_method()
		{
			_controller.ControllerContext = GetContextFor(_controller);

			_controller.Send(_page, _userModel);

			_service.VerifyAll();
		}

		[Test]
		public void Should_return_viewresult()
		{
			_controller.ControllerContext = GetContextFor(_controller);

			var result = _controller.Send(_page, _userModel);

			Assert.IsNotInstanceOf<JsonResult>(result);
			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void Should_return_json()
		{
			_controller.ControllerContext = GetContextFor(_controller, true);

			var result = _controller.Send(_page, _userModel);

			Assert.IsNotInstanceOf<ViewResult>(result);
			Assert.IsInstanceOf<JsonResult>(result);
		}

		private static ControllerContext GetContextFor(ControllerBase controller, bool isAjaxRequest = false)
		{
			var request = new Mock<HttpRequestBase>();

			request.SetupGet(x => x.Headers)
				.Returns(
					new System.Net.WebHeaderCollection
					{
						{"X-Requested-With", (isAjaxRequest ? "XMLHttpRequest" : "")}
					});

			var context = new Mock<HttpContextBase>();
			
			context
				.SetupGet(x => x.Request)
				.Returns(request.Object);

			return new ControllerContext(context.Object, new RouteData(), controller);
		}
	}
}
