using System.Collections.Generic;
using System.Linq;
using TaseToFood.Data.Models;

namespace TaseToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant{Id= 1, Cuisine=CuisineType.Italian, Name="Tase ITALIAN Bistro"},
                 new Restaurant{Id= 2, Cuisine=CuisineType.French, Name="Rouge Bullion"},
                  new Restaurant{Id= 3, Cuisine=CuisineType.Indian, Name="Pataks"},
                   new Restaurant{Id= 4, Cuisine=CuisineType.Italian, Name="Reubens"}
            };
        }

        public void Add(Restaurant restaurant)
        {
            _restaurants.Add(restaurant);
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
        }

        public void Delete(int id)
        {
            var restaurantToDelete = Get(id);
            if (restaurantToDelete!= null)
            {
                _restaurants.Remove(restaurantToDelete);
            }
          
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var restaurantExists = Get(restaurant.Id);
            if (restaurantExists!=null)
            {
                restaurantExists.Name = restaurant.Name;
                restaurantExists.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
