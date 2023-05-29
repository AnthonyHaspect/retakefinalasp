using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pAspFinal.Models;
using pAspFinal.ViewModels;

namespace pAspFinal.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _LesQuestions;
        private readonly pAspFinal_dbContext _dbContext;
        public QuestionController(IQuestionRepository lesQuestions, pAspFinal_dbContext dbContext)
        {
            this._LesQuestions = lesQuestions;
            _dbContext = dbContext;
        }

        public ViewResult Liste()
        {
            ViewBag.Titre = "Les questions";
            return View(_LesQuestions.GetAll);
        }


        public ViewResult Details(int id)
        {
            Question question = _LesQuestions.GetById(id);

            return View(question);
        }


        [HttpGet]
        public ViewResult Ajouter()
        {
            ViewBag.Titre = "Ajouter";
            //retourne le un object qui contient tout les question sections et types
            var viewModel = new AjouterQuestionViewModel
            {
                Question = new Question(),
                Questions = _dbContext.Questions.ToList(),
                Sections = _dbContext.Sections.ToList(),
                Types = _dbContext.Types.ToList()
            };
            return View(viewModel);
        }

        /// <summary>
        /// est utiliser par le formulaire ajouter cependant il prend les modification et les ajout
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Ajouter(Question question)
        {
            //_LesQuestions.Modifier(question);
            //_dbContext.SaveChanges();
            //if (ModelState.IsValid)
            //{
                //si le id est 0 on créer un nouvelle item
                if (question.Id == 0)
                {
                    _LesQuestions.Ajouter(question);
                }
                //si le id est pas 0 on chercher pour une question avec le meme id et on le modifi
                else
                {
                    //Question EnQuestion = _dbContext.Questions.Find(question.Id);
                    if (question.Id != 0)
                    {
                    _LesQuestions.Modifier(question);
                    }

                }
            //}
            return RedirectToAction(nameof(Liste));
        }


        [HttpGet]
        public ViewResult Modifier(int id)
        {
            ViewBag.Titre = "Modifier";
            Question question = _LesQuestions.GetById(id);
            var viewModel = new AjouterQuestionViewModel 
            { Question = question,
                Questions = _dbContext.Questions.ToList(),
                Sections = _dbContext.Sections.ToList(),
                Types = _dbContext.Types.ToList(),
            };
            return View("Ajouter", viewModel);
        }


        /*[HttpPost]
        public RedirectToActionResult Modifier(Question question)
        {
            _LesQuestions.Modifier(question);
            return RedirectToAction(nameof(Details), new { id = question.Id });
        }*/


        [HttpGet]
        public IActionResult Supprimer(int id)
        {
            //var question = await _dbContext.Questions.FindAsync(id);
            //_dbContext.Questions.Remove(question);
           // await _dbContext.SaveChangesAsync();
            _LesQuestions.Supprimer(id);
            return RedirectToAction(nameof(Liste));
        }
    }
}
