using Microsoft.EntityFrameworkCore;

namespace matAppBackEnd.Models
{
    public class ListingAllergieDbContext : DbContext
    {
        public ListingAllergieDbContext(DbContextOptions<ListingAllergieDbContext> options)
            : base(options)
        {
        }

        public DbSet<ListingAllergie> ListingAllergie { get; set; }
    }
   
}
