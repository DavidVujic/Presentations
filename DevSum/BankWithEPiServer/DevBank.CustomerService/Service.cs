using System;
using AutoMapper;
using DevBank.CustomerService.Entities;
using DevBank.CustomerService.Helpers;
using DevBank.CustomerService.ServiceRef;
using DevBank.Logging;
using DevBank.Proxy;

namespace DevBank.CustomerService
{
	public class Service : IService
	{
		private readonly IProxy _proxy;
		private readonly IBankLogger _logger;

		public Service(IProxy proxy, IBankLogger logger)
		{
			_proxy = proxy;

			_logger = logger;

			MapHelper.Configure();
		}

		public LocalCustomer GetCustomerBy(string socialSecurityNumber)
		{
			var request = new GetCustomerRequest(socialSecurityNumber);

			_logger.Add(request);

			Func<ICustomerService, GetCustomerResponse> function = service => service.GetCustomer(request);

			var response = _proxy.Call(function);

			_logger.Add(response);

			return Mapper.Map<LocalCustomer>(response.GetCustomerResult);
		}
	}
}