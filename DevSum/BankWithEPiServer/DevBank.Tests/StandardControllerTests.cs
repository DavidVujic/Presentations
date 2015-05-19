using System.Web.Mvc;
using DevBank.Business.ServiceFactories;
using DevBank.Controllers;
using DevBank.Models.Pages;
using DevBank.Models.ViewModels;
using Moq;
using NUnit.Framework;

namespace DevBank.Tests
{
	[TestFixture]
	public class StandardControllerTests
	{
		[Test]
		public void Should_return_view_model()
		{
			var factory = new Mock<ICustomerFactory>();

			var page = new StandardPage();

			var controller = new StandardController(factory.Object);

			var result = controller.Index(page) as ViewResult;

			Assert.IsNotNull(result);
			Assert.True(result.Model is PageViewModel<StandardPage>);
		}
	}
}
