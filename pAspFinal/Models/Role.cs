using System.ComponentModel.DataAnnotations;

namespace pAspFinal.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Utilisateur>? Utilisateurs { get; set; }//relation 1 à N
    }
}
