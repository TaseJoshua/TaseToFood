using System;
using System.Web.Mvc;
using TaseToFood.Data.Models;
using TaseToFood.Data.Services;

namespace TaseToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData _dataBase;

        public RestaurantsController(IRestaurantData dataBase)
        {
            _dataBase = dataBase;
        }
        // GET: Restaurants
        [HttpGet]
        public ActionResult Index()
        {
            var model = _dataBase.GetAllRestaurants();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _dataBase.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {

            if (ModelState.IsValid)
            {
                _dataBase.Add(restaurant);
                return RedirectToAction("Details",new { id = restaurant.Id});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _dataBase.Get(id);
            if (model ==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _dataBase.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant!";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _dataBase.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            _dataBase.Delete(id);
            return RedirectToAction("Index");
        }
    }
}