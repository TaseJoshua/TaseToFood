using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaseToFood.Data.Models;

namespace TaseToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly TaseToFoodDbContext _dbContext;

        public SqlRestaurantData(TaseToFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurantToDelete = _dbContext.Restaurants.Find(id);
            if (restaurantToDelete!=null)
            {
                _dbContext.Restaurants.Remove(restaurantToDelete);
                _dbContext.SaveChanges();
            }

        }

        public Restaurant Get(int id)
        {
           return _dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
            
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return from r in _dbContext.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            var entry = _dbContext.Entry(restaurant);
            entry.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
