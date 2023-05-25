using Microsoft.AspNetCore.Mvc;
using pAspFinal.Models;

namespace pAspFinal.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _LesQuestions;
        public QuestionController(IQuestionRepository lesQuestions)
        {
            this._LesQuestions = lesQuestions;
        }



        public ViewResult Liste()
        {
            ViewBag.Titre = "Les questions";
            return View(_LesQuestions.GetAll);
        }


        public ViewResult DetailsQuestion(int id)
        {
            Question question = _LesQuestions.GetById(id);

            return View("Details", question);
        }


        [HttpGet]
        public ViewResult Ajouter()
        {
            return View();
        }


        [HttpPost]
        public RedirectToActionResult Ajouter(Question question)
        {
            _LesQuestions.Ajouter(question);
            return RedirectToAction(nameof(Liste));
        }


        [HttpGet]
        public ViewResult Modifier(int id)
        {
            Question question = _LesQuestions.GetById(id);
            return View(question);
        }


        [HttpPost]
        public RedirectToActionResult Modifier(Question question)
        {
            _LesQuestions.Modifier(question);
            return RedirectToAction(nameof(DetailsQuestion), new { id = question.Id });
        }
    }
}
