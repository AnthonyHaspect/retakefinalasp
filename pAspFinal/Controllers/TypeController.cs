using Microsoft.AspNetCore.Mvc;
using pAspFinal.Models;

namespace pAspFinal.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeRepository _LesTypes;
        public TypeController(ITypeRepository lesTypes)
        {
            this._LesTypes = lesTypes;
        }


        /// <summary>
        /// Méthode qui affiche les types
        /// </summary>
        /// <returns>la vue liste</returns>
        public ViewResult Liste()
        {
            ViewBag.Titre = "Les types";
            return View(_LesTypes.GetAll);
        }

        /// <summary>
        /// Méthode qui permet d'afficher un type pour voir les information et les action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewResult Details(int id)
        {
            Models.Type type = _LesTypes.GetById(id);

            return View("Details", type);
        }
        /// <summary>
        /// affiche la page pour créer 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Ajouter()
        {
            return View();
        }
        /// <summary>
        /// ajouter un type a la liste
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        public RedirectToActionResult Ajouter(Models.Type type)
        {
            _LesTypes.Ajouter(type);
            return RedirectToAction(nameof(Liste));
        }
        /// <summary>
        /// modifie un type
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retourne la vue modifier</returns>
        [HttpGet]
        public ViewResult Modifier(int id)
        {
            Models.Type type = _LesTypes.GetById(id);
            return View(type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns>retourne la vue </returns>
        [HttpPost]
        public RedirectToActionResult Modifier(Models.Type type)
        {
            _LesTypes.Modifier(type);
            return RedirectToAction(nameof(Details), new {id = type.Id});
        }


        /// <summary>
        /// Supprime un type
        /// probablement ne vont pas être utiliser
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retourne la vue liste</returns>
        [HttpPost]
        public RedirectToActionResult Supprimer(int id)
        {
            _LesTypes.Supprimer(id);
            return RedirectToAction(nameof(Liste));
        }
    }
}
