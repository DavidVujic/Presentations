﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestdrivenJavaScript.Controllers;

namespace TestdrivenJavaScript.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			var controller = new HomeController();

			// Act
			var result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
