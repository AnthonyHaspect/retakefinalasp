using pAspFinal.Models;
using Microsoft.AspNetCore.Identity;

namespace pAspFinal.ViewModels
{
    public class RolesUtilisateurViewModel
    {
        public IdentityRole Role { get; set; }
        public Utilisateur User { get; set; }
        
    }
}
