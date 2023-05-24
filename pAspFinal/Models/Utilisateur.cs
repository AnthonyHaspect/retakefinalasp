using System.ComponentModel.DataAnnotations;

namespace pAspFinal.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Compagnie { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Formulaire> Formulaire { get; set; }
    }
}
