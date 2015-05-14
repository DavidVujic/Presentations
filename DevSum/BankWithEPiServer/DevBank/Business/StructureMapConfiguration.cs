using DevBank.Business.ServiceFactories;
using DevBank.Logging;
using DevBank.Proxy;
using StructureMap;

namespace DevBank.Business
{
	/// <summary>
	/// StructureMap dependency resolver configuration: from interface to implementation
	/// </summary>
	public class StructureMapConfiguration
	{
		public static void Configure(IContainer container)
		{
			container.Configure(x =>
			{
				x.For<IBankLogger>()
					.Use<DemoLogger>();

				x.For<IProxy>()
					.Use<Proxy.Proxy>();

				x.For<CustomerService.IService>()
					.Singleton()
					.Use<CustomerService.Service>();

				x.For<CustomerService.IService>()
					.Singleton()
					.Use<CustomerService.Fake.FakeService>();

				x.For<ICustomerFactory>()
					.Singleton()
					.Use<CustomerFactory>();
			});
		}
	}
}