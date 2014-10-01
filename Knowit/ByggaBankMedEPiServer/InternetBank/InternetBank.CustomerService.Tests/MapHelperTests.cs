using AutoMapper;
using InternetBank.CustomerService.Helpers;
using NUnit.Framework;

namespace InternetBank.CustomerService.Tests
{
	[TestFixture]
    public class MapHelperTests
    {
		[Test]
		public void Should_map_to_local_domain_object()
		{
			MapHelper.Configure();

			Mapper.AssertConfigurationIsValid();
		}
    }
}
