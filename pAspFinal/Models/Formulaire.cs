namespace pAspFinal.Models
{
    public class Formulaire
    {
        public int Id { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Utilisateur>? Utilisateurs { get; set; } //les utilisateurs qui y ont accèes
        public string Nom { get; set; } //le nom du formulaire
    }
}
