using DevBank.CustomerService.Entities;

namespace DevBank.CustomerService
{
	public interface IService
	{
		LocalCustomer GetCustomerBy(string socialSecurityNumber);
	}
}
