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
						FirstName = "Kalle",
						LastName = "Anka",
						Phone = new Phone { Number = "123456789", Type = PhoneType.Home}
					};
					break;
				case "197405200473":
					customer = new Customer
					{
						CustomerId = 2,
						FirstName = "David",
						LastName = "Vujic",
						Phone = new Phone { Number = "0735200600", Type = PhoneType.Mobile }
					};
					break;
			}

			return customer;
		}
	}
}
