using System.Runtime.Serialization;
using System.ServiceModel;

namespace TheBankService
{
	[ServiceContract]
	public interface ICustomerService
	{
		[OperationContract]
		Customer GetCustomer(string socialSecurityNumber);
	}

	[DataContract]
	public class Customer
	{
		[DataMember]
		public int CustomerId { get; set; }
		
		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string LastName { get; set; }

		[DataMember]
		public Phone Phone { get; set; }
	}

	[DataContract]
	public class Phone
	{
		[DataMember]
		public string Number { get; set; }

		[DataMember]
		public PhoneType Type { get; set; }
	}

	[DataContract]
	public enum PhoneType
	{
		[EnumMember]
		Mobile,

		[EnumMember]
		Home,

		[EnumMember]
		Work
	}
}
