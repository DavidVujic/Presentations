using System.Web.Mvc;
using WebbProjektet.Services;

namespace WebbProjektet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;

        public HomeController(IUserService service)
        {
	        _service = service;
        }

        public ViewResult Index()
        {
            var users = _service.GetUsers();

            return View(users);
        }
    }
}
