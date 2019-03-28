using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefDishes.Models;

namespace ChefDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            // Displays list of created chefs
            List<Chef> AllChefs = dbContext.Chefs.Include(c => c.CreatedFood).ToList();
            ViewBag.TotalChefs = AllChefs;
            return View();
        }

        [Route("Food")]
        [HttpGet]

        public IActionResult Food()
        {
            List<Food> AllFood = dbContext.Foods.Include(f => f.Cook).ToList();
            ViewBag.TotalFood = AllFood;
            return View("Food");
        }

        [Route("Addchef")]
        [HttpGet]
        public IActionResult NewChef()
        {
            return View("AddChef");
        }


        [Route("AddFood")]
        [HttpGet]
        public IActionResult NewFood()
        {
            List<Chef> AllChef = dbContext.Chefs.Include(c => c.CreatedFood).ToList();
            ViewBag.Tasty = AllChef;
            return View("AddFood");
        }

        [Route("CreateChef")]
        [HttpPost]

        public IActionResult CreateChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
            dbContext.Chefs.Add(newChef);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }

        }
        [Route("CreateFood")]
        [HttpPost]

        public IActionResult CreateFood(Food newFood)
        {
            if (ModelState.IsValid)
            {
                dbContext.Foods.Add(newFood);
                dbContext.SaveChanges();
                return RedirectToAction("Food"); 
            }
            else
            {
                return View("AddFood");
            }
        }

        

    }
}
