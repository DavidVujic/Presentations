using InternetBank.CustomerService;

namespace InternetBank.Business.ServiceFactories
{
	public interface ICustomerFactory
	{
		IService GetService();
	}
}