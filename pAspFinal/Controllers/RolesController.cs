using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pAspFinal.Models;
using pAspFinal.ViewModels;

namespace pAspFinal.Controllers
{
    //référence : cour sur l'authorization et authentification fait en classe
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<Utilisateur> _userManager;
        private readonly pAspFinal_dbContext _dbContext;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<Utilisateur> userManager, pAspFinal_dbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public ViewResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Creer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Creer(CreerRolesViewModel model)
        {
            IdentityRole role = await _roleManager.FindByNameAsync(model.NomDeRole);

            if (role != null)
            {
                ModelState.AddModelError(model.NomDeRole, "Ce nom de rôle existe déjà, veuillez choisir un autre.");
                return View(nameof(Creer), model.NomDeRole);
            }

            if (ModelState.IsValid)
            {
                IdentityRole nvRole = new IdentityRole
                {
                    Name = model.NomDeRole
                };

                IdentityResult result = await _roleManager.CreateAsync(nvRole);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(nameof(Creer), model);
        }

        public async Task<IActionResult> Supprimer(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View("Index", _roleManager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> ModifierRoleUsager(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            IList<Utilisateur> membres = new List<Utilisateur>();
            List<Utilisateur> nonMembres = new List<Utilisateur>();

            var Utili = _userManager.Users.ToList(); 

            membres = await _userManager.GetUsersInRoleAsync(role.Name);
            nonMembres = Utili.Where(user => !_userManager.IsInRoleAsync(user, role.Name).Result).ToList();

            RolesUtilisateurViewModel membresRoleVM = new RolesUtilisateurViewModel
            {
                Role = role,
                NonMembres = nonMembres,
                Membres = membres
            };

            return View(membresRoleVM);
        }

        [HttpPost]
        public async Task<IActionResult> ModifierRoleUsager(string roleId, string userId, string modif)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                Utilisateur user = await _userManager.FindByIdAsync(userId);
                IdentityRole role = await _roleManager.FindByIdAsync(roleId);

                if (user != null && role != null)
                {
                    if (modif == "-1")
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        result = await _userManager.AddToRoleAsync(user, role.Name);

                    }

                    if (!result.Succeeded)
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

            }

            return RedirectToAction(nameof(Index)/*, "Roles", new { id = roleId }*/);

        }

    }

}
