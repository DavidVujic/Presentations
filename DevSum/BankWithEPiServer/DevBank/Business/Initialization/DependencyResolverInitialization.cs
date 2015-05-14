using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using StructureMap;

namespace DevBank.Business.Initialization
{
	[ModuleDependency(typeof(ServiceContainerInitialization))]
	public class DependencyResolverInitialization : IConfigurableModule
	{
		private IContainer _container;

		public void ConfigureContainer(ServiceConfigurationContext context)
		{
			_container = context.Container;

			var resolver = new StructureMapDependencyResolver(context.Container);

			DependencyResolver.SetResolver(resolver);
		}

		public void Initialize(InitializationEngine context)
		{
			StructureMapConfiguration.Configure(_container);
		}

		public void Uninitialize(InitializationEngine context)
		{
		}

		public void Preload(string[] parameters)
		{
		}
	}
}