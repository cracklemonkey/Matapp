using Microsoft.EntityFrameworkCore;

namespace matAppBackEnd.Models
{
    public class ListingDbContext : DbContext
    {
        public ListingDbContext(DbContextOptions<ListingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Listing> Listings { get; set; }
    }
   
}
