using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pAspFinal.Models;
using pAspFinal.ViewModels;

namespace pAspFinal.Controllers
{
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<Utilisateur> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<Utilisateur> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public ViewResult Index()
        {
            return View(_roleManager.Roles);
        }
        [HttpGet]
        public IActionResult Creer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Creer(CreerRolesViewModel model)
        {
            IdentityRole role = await _roleManager.FindByNameAsync(model.RoleName);

            if (role != null)
            {
                ModelState.AddModelError(model.RoleName, "Ce nom de rôle existe déjà, veuillez choisir un autre.");
                return View(nameof(Creer), model.RoleName);
            }

            if (ModelState.IsValid)
            {
                IdentityRole nvRole = new IdentityRole
                {
                    Name = model.RoleName
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

            List<Utilisateur> listeUsagers = _userManager.Users.ToList();

            membres = await _userManager.GetUsersInRoleAsync(role.Name);
            nonMembres = _userManager.Users.Where(user => !membres.Contains(user)).ToList();

            RolesUtilisateurViewModel membresRoleVM = new RolesUtilisateurViewModel
            {
                Role = role,
                //NonMembres = nonMembres,
                //Membres = membres
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

            return RedirectToAction(nameof(ModifierRoleUsager), "Roles", new { id = roleId });

        }

    }

}
