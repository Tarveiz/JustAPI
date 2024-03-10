using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
