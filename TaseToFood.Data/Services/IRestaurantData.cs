using System.Collections.Generic;
using TaseToFood.Data.Models;

namespace TaseToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant Get(int id);

        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(int id);
    }
}
