using System.ComponentModel.DataAnnotations;
using InternetBank.Business.Validation;

namespace InternetBank.Models.ViewModels
{
	public class UserModel
	{
		[Required]
		[SocialSecurityNumber]
		public string SocialSecurityNumber { get; set; }
	}
}