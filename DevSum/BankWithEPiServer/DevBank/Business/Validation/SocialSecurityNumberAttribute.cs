using System.ComponentModel.DataAnnotations;
using Microsoft.Security.Application;

namespace DevBank.Business.Validation
{
	public class SocialSecurityNumberAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var input = value as string;

			if (string.IsNullOrEmpty(input))
			{
				return true;
			}

			var sanitized = Sanitizer.GetSafeHtmlFragment(input);

			return sanitized == input;
		}
	}
}