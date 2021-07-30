using System.Web.Mvc;
using TaseToFood.Data.Services;

namespace TaseToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData _dataBase;

        public HomeController(IRestaurantData db)
        {
            _dataBase = db;
        }
        public ActionResult Index()
        {
            var model = _dataBase.GetAllRestaurants();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}