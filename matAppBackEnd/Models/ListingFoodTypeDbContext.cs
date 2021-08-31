using Microsoft.EntityFrameworkCore;

namespace matAppBackEnd.Models
{
    public class ListingFoodTypeDbContext : DbContext
    {
        public ListingFoodTypeDbContext(DbContextOptions<ListingFoodTypeDbContext> options)
            : base(options)
        {
        }

        public DbSet<ListingFoodType> ListingFoodType { get; set; }
    }
   
}
