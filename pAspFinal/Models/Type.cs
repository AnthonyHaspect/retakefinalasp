using System.ComponentModel.DataAnnotations;

namespace pAspFinal.Models
{
    public class Type
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Nom { get; set; }
        [Required]
        [StringLength(25)]
        public string Balise { get; set; }
        public string? type { get; set; }
        public List<Question>? Questions { get; set; }  //relation 1 à N

    }
}
