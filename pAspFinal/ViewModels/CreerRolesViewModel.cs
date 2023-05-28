using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace pAspFinal.ViewModels
{
    public class CreerRolesViewModel
    {
        [Required]
        [Display(Name = "Nom du role")]
        [StringLength(15, ErrorMessage = "Le {0} doit être entre {2} et {1} caractères" , MinimumLength =2)]
        public string NomDeRole { get; set; }
    }
}
