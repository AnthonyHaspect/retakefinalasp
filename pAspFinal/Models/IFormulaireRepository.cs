namespace pAspFinal.Models
{
    public interface IFormulaireRepository
    {
        public List<Formulaire> GetAll { get; }
        public Formulaire GetById(int id);
        public void Ajouter(Formulaire formulaire);
        public void Modifier(Formulaire formulaire);
        public void Supprimer(Formulaire formulaire);
    }
}
