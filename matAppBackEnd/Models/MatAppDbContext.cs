using Microsoft.EntityFrameworkCore;

namespace matAppBackEnd.Models
{
    public class MatAppDbContext : DbContext
    {
        public MatAppDbContext(DbContextOptions<MatAppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Allergie> Allergies { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<ListingAllergie> ListingAllergie { get; set; }
        public DbSet<ListingFoodType> ListingFoodType { get; set; }
        public DbSet<OrderListing> OrderListings { get; set; }
        public DbSet<OrderedListing> OrderedListings { get; set; }
        public DbSet<AllColumns> AllColumns { get; set; }
        public DbSet<FullFoodType> FullFoodType { get; set; }
        public DbSet<FullAllergie> FullAllergie { get; set; }
        public DbSet<FullOrderListing> FullOrderListings { get; set; }
        
    }
   
}
