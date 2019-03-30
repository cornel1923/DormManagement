using Microsoft.AspNetCore.Mvc;

namespace DormManagement.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}