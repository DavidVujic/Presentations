using System.Collections.Generic;
using WebbProjektet.Models;

namespace WebbProjektet.Services
{
	public class UserService : IUserService
	{
		public List<Person> GetUsers()
		{
			return new List<Person>
			{
				new Person {Name = "Scott Guthrie"},
				new Person {Name = "Scott Hanselman"},
				new Person {Name = "Scott Allen"}
			};
		}
	}
}