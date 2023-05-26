using Microsoft.EntityFrameworkCore;
using pAspFinal.Models;

namespace pAspFinal.Models
{
    public class BDFormulaireRepository : IFormulaireRepository
    {
        private readonly pAspFinal_dbContext _DbContext;
        public BDFormulaireRepository(pAspFinal_dbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public List<Formulaire> GetAll
        {
            get
            {
                return _DbContext.Formulaires.OrderBy(f=>f.Id).ToList();
            }
        }

        public void Ajouter(Formulaire formulaire)
        {
            _DbContext.Formulaires.Add(formulaire);
            _DbContext.SaveChanges();
        }

        public Formulaire GetById(int id)
        {
            return _DbContext.Formulaires.FirstOrDefault(f => f.Id == id);
        }

        public void Modifier(Formulaire formulaire)
        {
            _DbContext.Formulaires.Update(formulaire);
            _DbContext.SaveChanges();
        }

        public void Supprimer(Formulaire formulaire)
        {
            _DbContext.Formulaires.Remove(formulaire);
            _DbContext.SaveChanges();
        }
    }
}
