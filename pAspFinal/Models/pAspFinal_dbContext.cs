using Microsoft.EntityFrameworkCore;

namespace pAspFinal.Models
{
    public class pAspFinal_dbContext : DbContext
    {
        public pAspFinal_dbContext(DbContextOptions<pAspFinal_dbContext> options) : base(options) 
        {

        }

    }
}
