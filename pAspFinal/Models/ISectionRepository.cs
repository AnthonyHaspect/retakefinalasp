namespace pAspFinal.Models
{
    public interface ISectionRepository
    {
        public List<Section> GetAll { get; }
        public Section GetById(int id);
        public void Ajouter(Section section);
        public void Modifier(Section section);
        public void Supprimer(int id);
    }
}
