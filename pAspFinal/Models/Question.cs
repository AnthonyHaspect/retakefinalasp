using System.ComponentModel.DataAnnotations;

namespace pAspFinal.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }//est la question en tant que telle
        public List<string>? Choix { get; set; }//est le choix des réponse si la questions a des choix
        public string? Commentaire { get; set; }//les précision
        public string? ParDefault { get; set; }
        public int? ParentID { get; set; }//clé étrangère qui li la question a son parent (peut être null)
        public Question? Parent { get; set; } //peut avoir une question parent (peut être null)
        public List<Question>? Children { get; set; }
        public int TypeID { get; set; }//clé étrangère qui li la question au type
        public Type Type { get; set; } //possède seulement un type
        public int SectionID { get; set; } //clé étrangère qui li la question a la section
        public Section Section { get; set; } //est dans seulement une section
        public List<Formulaire>? Formulaires { get; set; }
        
        
        //réponses va être une session ou un cookie
    }
}
