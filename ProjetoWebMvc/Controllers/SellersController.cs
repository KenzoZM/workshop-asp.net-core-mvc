using Microsoft.AspNetCore.Mvc;

namespace ProjetoWebMvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
