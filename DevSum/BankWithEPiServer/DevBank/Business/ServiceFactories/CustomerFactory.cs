using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Security;
using DevBank.CustomerService;
using DevBank.CustomerService.Fake;

namespace DevBank.Business.ServiceFactories
{
	public class CustomerFactory : ICustomerFactory
	{
		public IService GetService()
		{
			var services = DependencyResolver.Current.GetServices<IService>();

			if (IsEditor() || ShouldUseFake())
			{
				return services.OfType<FakeService>().FirstOrDefault();
			}

			return services.OfType<Service>().FirstOrDefault();
		}

		private static bool IsEditor()
		{
			return PrincipalInfo.HasEditAccess;
		}

		private static bool ShouldUseFake()
		{
			bool isFake;

			bool.TryParse(ConfigurationManager.AppSettings["UseFakeServices"], out isFake);

			return isFake;
		}
	}
}