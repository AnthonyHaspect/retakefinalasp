using Microsoft.AspNetCore.Mvc;

namespace pAspFinal.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
