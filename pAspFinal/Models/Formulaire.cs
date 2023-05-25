namespace pAspFinal.Models
{
    public class Formulaire
    {
        public int Id { get; set; }
        public string Nom { get; set; } //le nom du formulaire
        public List<Question> Questions { get; set; }
        public List<Utilisateur>? Utilisateurs { get; set; } //les utilisateurs qui y ont accèes

    }
}
