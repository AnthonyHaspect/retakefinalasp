using System.ComponentModel.DataAnnotations;

namespace pAspFinal.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public List<Question>? Questions { get; set;} //relation 1 à N
    }
}
