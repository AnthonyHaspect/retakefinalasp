﻿namespace pAspFinal.Models
{
    public class BDQuestionRepository : IQuestionRepository
    {
        private readonly pAspFinal_dbContext _DbContext;
        public BDQuestionRepository(pAspFinal_dbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public List<Question> GetAll
        {
            get
            {
                return _DbContext.Questions.OrderBy(q => q.Id).ToList();
            }
        }

        public void Ajouter(Question question)
        {
            _DbContext.Questions.Add(question);
            _DbContext.SaveChanges();
        }

        public Question GetById(int id)
        {
            return _DbContext.Questions.FirstOrDefault(q => q.Id == id);
        }

        public void Modifier(Question question)
        {
            _DbContext.Questions.Update(question);
            _DbContext.SaveChanges();
        }

        public void Supprimer(Question question)
        {
            _DbContext.Remove(question);
            _DbContext.SaveChanges();
        }
    }
}
