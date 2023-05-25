using Microsoft.AspNetCore.Mvc;
using pAspFinal.Models;

namespace pAspFinal.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionRepository _LesSections;
        public SectionController(ISectionRepository lesSections)
        {
            this._LesSections = lesSections;
        }



        public ViewResult Liste()
        {
            ViewBag.Titre = "Les sections";
            return View(_LesSections.GetAll);
        }


        public ViewResult DetailsSection(int id)
        {
            Section section = _LesSections.GetById(id);

            return View("Details", section);
        }


        [HttpGet]
        public ViewResult Ajouter()
        {
            return View();
        }


        [HttpPost]
        public RedirectToActionResult Ajouter(Section section)
        {
            _LesSections.Ajouter(section);
            return RedirectToAction(nameof(Liste));
        }


        [HttpGet]
        public ViewResult Modifier(int id)
        {
            Section section = _LesSections.GetById(id);
            return View(section);
        }


        [HttpPost]
        public RedirectToActionResult Modifier(Section section)
        {
            _LesSections.Modifier(section);
            return RedirectToAction(nameof(DetailsSection), new { id = section.Id });
        }
    }
}
