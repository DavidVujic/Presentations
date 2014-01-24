using System.Collections.Generic;
using NUnit.Framework;
using WebbProjektet.Controllers;
using WebbProjektet.Models;
using WebbProjektet.Services;

namespace WebbProjektet.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
		[Test]
		public void Ett_exempel()
		{
			// Arrange
			var fakeService = new FakeService();
			var controller = new HomeController(fakeService);

			// Act
			var result = controller.Index();

			// Assert
			Assert.IsNotNull(result.Model);
		}
    }

    public class FakeService : IUserService
    {
        public List<Person> GetUsers()
        {
            return new List<Person>();
        }
    }
}