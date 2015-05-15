namespace TheBankService
{
	public class CustomerService : ICustomerService
	{
		public Customer GetCustomer(string socialSecurityNumber)
		{
			Customer customer = null;
			
			switch (socialSecurityNumber)
			{
				case "191212121212":
					customer = new Customer
					{
						CustomerId = 1,
						FirstName = "Donald",
						LastName = "Duck",
						Phone = new Phone { Number = "123456789", Type = PhoneType.Home}
					};
					break;
				case "191010101010":
					customer = new Customer
					{
						CustomerId = 2,
						FirstName = "David",
						LastName = "Vujic",
						Phone = new Phone { Number = "999999999", Type = PhoneType.Mobile }
					};
					break;
			}

			return customer;
		}
	}
}
