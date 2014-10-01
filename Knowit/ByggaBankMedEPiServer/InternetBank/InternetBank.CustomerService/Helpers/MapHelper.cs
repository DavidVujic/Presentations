using AutoMapper;
using InternetBank.CustomerService.Entities;
using InternetBank.CustomerService.ServiceRef;

namespace InternetBank.CustomerService.Helpers
{
	public static class MapHelper
	{
		public static void Configure()
		{
			Mapper.CreateMap<Customer, LocalCustomer>()
				.ForMember(destination => destination.Telephone, opt => opt.MapFrom(src => src.Phone.Number));
		}
	}
}
