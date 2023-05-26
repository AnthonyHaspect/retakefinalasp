namespace pAspFinal.Models
{
    public class BDTypeRepository : ITypeRepository
    {
        private readonly pAspFinal_dbContext _DbContext;
        public BDTypeRepository(pAspFinal_dbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public List<Type> GetAll
        {
            get
            {
                return _DbContext.Types.OrderBy(t=>t.Nom).ToList();
            }
        }

        public void Ajouter(Type type)
        {
            _DbContext.Types.Add(type);
            _DbContext.SaveChanges();
        }

        public Type GetById(int Id)
        {
            return _DbContext.Types.FirstOrDefault(t => t.Id == Id);
        }

        public void Modifier(Type type)
        {
            _DbContext.Types.Update(type);
            _DbContext.SaveChanges();
        }

        public void Supprimer(int id)
        {
            Type type = _DbContext.Types.FirstOrDefault(t => t.Id == id);
            if (type != null)
            {
                _DbContext.Types.Remove(type);
                _DbContext.SaveChanges();
            }
            
        }
    }
}
