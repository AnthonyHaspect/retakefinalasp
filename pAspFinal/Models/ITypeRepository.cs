namespace pAspFinal.Models
{
    public interface ITypeRepository
    {
        //tout les type de question
        public List<Type> GetAll { get; }
        //un type
        public Type GetById(int typeId);
        //ajouter
        public void Ajouter(Type type);
        //Modifier
        //probablement pas utiliser modifier car ce n'est pas une chose pour un utilisateur normal mais seulement pour l'affichage html
        public void Modifier(Type type);
        //supprimer
        public void Supprimer(Type type);
    }
}
