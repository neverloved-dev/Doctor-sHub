using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class PrescriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
