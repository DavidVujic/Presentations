using System.ComponentModel.DataAnnotations;
using NoScriptFirst.Validation;

namespace NoScriptFirst.Models
{
	public class Person
	{
		[MittLillaAttribut]
		public string FullName { get; set; }
		
		[Range(10, 100)]
		public int Age { get; set; }
	}
}