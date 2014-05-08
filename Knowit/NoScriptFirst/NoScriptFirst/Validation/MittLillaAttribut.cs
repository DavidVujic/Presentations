using System.ComponentModel.DataAnnotations;
using Microsoft.Security.Application;

namespace NoScriptFirst.Validation
{
	public class MittLillaAttribut : RequiredAttribute
	{
		public override bool IsValid(object value)
		{
			var sanitized = Sanitizer.GetSafeHtmlFragment(value as string);

			return base.IsValid(sanitized);
		}
	}
}