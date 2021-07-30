using System.Collections.Generic;
using TaseToFood.Data.Models;

namespace TaseToFood.Web.Models
{
    public class GreetingViewModel
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
