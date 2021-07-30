using System.Data.Entity;
using TaseToFood.Data.Models;

namespace TaseToFood.Data.Services
{
    public class TaseToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
