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

		[SetUp]
		public void Setup()
		{
			_service = new Mock<IService>();
			_factory = new Mock<ICustomerFactory>();

			_factory
				.Setup(f => f.GetService())
				.Returns(_service.Object);

			_controller = new StandardController(_factory.Object);

			_page = new StandardPage();
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

			const string socialSecurityNumber = "191010101010";

			_service
				.Setup(s => s.GetCustomerBy(socialSecurityNumber))
				.Returns(new LocalCustomer());

			_controller.Send(_page, new UserModel { SocialSecurityNumber = socialSecurityNumber });

			_service.VerifyAll();
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
