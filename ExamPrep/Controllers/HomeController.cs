using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPrep.Models;
using ExamPrep.Services;
using ExamPrep.ViewModels;

namespace ExamPrep.Controllers
{
    //Denne controller får en request til Root af app. 
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            return View(model);
        }

        //Her finder man et ID paramet og tager den korrekte restaurant ID
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            //Her redirecter vi de url's der er uden for ID af restauranter og sender dem tilbage til index.cshtml
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        //HttpGET er for at LÆSE data!
        //HttpGet fortæller at den kun skal gøre nedenstående når den får et get req
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //HttpPOST er for at SKRIVE data!
        //Her responderer den kun til post
        [HttpPost]
        public IActionResult Create(RestaurantEditModel model)
        {
            var newRestaurant = new Restaurant();
            newRestaurant.Name = model.Name;
            newRestaurant.Cuisine = model.Cuisine;

           newRestaurant = _restaurantData.Add(newRestaurant);

            return RedirectToAction(nameof(Details), new {id = newRestaurant.Id});
        }

    }
}
