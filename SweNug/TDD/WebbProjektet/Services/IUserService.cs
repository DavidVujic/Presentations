using System.Collections.Generic;
using WebbProjektet.Models;

namespace WebbProjektet.Services
{
    public interface IUserService
    {
        List<Person> GetUsers();
    }
}