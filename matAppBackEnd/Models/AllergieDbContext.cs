using Microsoft.EntityFrameworkCore;

namespace matAppBackEnd.Models
{
    public class AllergieDbContext : DbContext
    {
        public AllergieDbContext(DbContextOptions<AllergieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Allergie> Allergies { get; set; }
    }
   
}
