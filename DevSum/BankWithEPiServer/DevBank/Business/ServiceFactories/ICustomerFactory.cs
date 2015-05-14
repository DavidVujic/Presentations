using DevBank.CustomerService;

namespace DevBank.Business.ServiceFactories
{
	public interface ICustomerFactory
	{
		IService GetService();
	}
}