using InternetBank.CustomerService.Entities;

namespace InternetBank.CustomerService
{
	public interface IService
	{
		LocalCustomer GetCustomerBy(string socialSecurityNumber);
	}
}
