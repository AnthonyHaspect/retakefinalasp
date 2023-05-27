using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace pAspFinal.Models
{
    public class pAspFinal_dbContext : IdentityDbContext<Utilisateur>
    {
        public pAspFinal_dbContext(DbContextOptions<pAspFinal_dbContext> options) : base(options) 
        {

        }

        public DbSet<Formulaire> Formulaires { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Choix> Choixs { get; set; }

    }
}
