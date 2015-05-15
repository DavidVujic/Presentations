using System.ComponentModel.DataAnnotations;
using DevBank.Business.Validation;

namespace DevBank.Models.ViewModels
{
	public class UserModel
	{
		[Required]
		[SocialSecurityNumber]
		public string SocialSecurityNumber { get; set; }
	}
}