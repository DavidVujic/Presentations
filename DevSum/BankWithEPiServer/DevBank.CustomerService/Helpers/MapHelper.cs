using AutoMapper;
using DevBank.CustomerService.Entities;
using DevBank.CustomerService.ServiceRef;

namespace DevBank.CustomerService.Helpers
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
