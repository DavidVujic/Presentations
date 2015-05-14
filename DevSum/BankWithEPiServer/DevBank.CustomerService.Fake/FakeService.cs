using DevBank.CustomerService.Entities;

namespace DevBank.CustomerService.Fake
{
	public class FakeService : IService
	{
		public LocalCustomer GetCustomerBy(string socialSecurityNumber)
		{
			return new LocalCustomer
			{
				FirstName = "Pippilotta Viktualia Rullgardina Krusmynta Efraimsdotter",
				LastName = "Långstrump",
				Telephone = "12345678910"
			};
		}
	}
}
