using pAspFinal.Models;
using Microsoft.AspNetCore.Identity;

namespace pAspFinal.ViewModels
{
    public class RolesUtilisateurViewModel
    {
        public IdentityRole Role { get; set; }
        public IList<Utilisateur> Membres { get; set; }
        public List<Utilisateur> NonMembres { get; set; }        
    }
}
