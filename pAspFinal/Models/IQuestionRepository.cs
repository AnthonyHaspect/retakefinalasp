namespace pAspFinal.Models
{
    public interface IQuestionRepository
    {
        public List<Question> GetAll { get; }
        public Question GetById(int id);
        public void Ajouter(Question question); 
        public void Modifier(Question question);
        public void Supprimer(Question question);
    }
}
