using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace pAspFinal.Models
{
    public class Utilisateur : IdentityUser
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Compagnie { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Formulaire> Formulaire { get; set; }
    }
}
