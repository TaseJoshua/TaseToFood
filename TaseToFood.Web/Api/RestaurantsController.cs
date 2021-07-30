using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaseToFood.Data.Models;
using TaseToFood.Data.Services;

namespace TaseToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData _db;

        public RestaurantsController(IRestaurantData db)
        {
            _db = db;
        }
        public IEnumerable<Restaurant> Get()
        {

            var model = _db.GetAllRestaurants();
            return model;
        }
    }
}
