namespace pAspFinal.Models
{
    public class BDSectionRepository : ISectionRepository
    {
        private readonly pAspFinal_dbContext _DbContext;
        public BDSectionRepository(pAspFinal_dbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public List<Section> GetAll
        {
            get
            {
                return _DbContext.Sections.OrderBy(s => s.Id).ToList();
            }
        }

        public void Ajouter(Section section)
        {
            _DbContext.Sections.Add(section);
            _DbContext.SaveChanges();
        }

        public Section GetById(int id)
        {
            return _DbContext.Sections.FirstOrDefault(s => s.Id == id);
        }

        public void Modifier(Section section)
        {
            _DbContext.Sections.Update(section);
            _DbContext.SaveChanges();
        }

        public void Supprimer(int id)
        {
            Section section = _DbContext.Sections.FirstOrDefault(s => s.Id == id);
            if (section != null)
            {
                _DbContext.Sections.Remove(section);
                _DbContext.SaveChanges();

            }
        }
    }
}
