using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>(); 
        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewBag.cheeses = Cheeses;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            if (!string.IsNullOrEmpty(name) && System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
            {
                //Add the new cheese to my existing cheeses list
                Cheeses.Add(name, description);
                return Redirect("/Cheese");
            }
            else
            {
                return Redirect("/Cheese/Add");
            }
        }

        public IActionResult Remove()
        {
            //Displays the form needed to remove a cheese form the list
            ViewBag.cheeses = Cheeses;
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveCheese(string cheese)
        {
            Cheeses.Remove(cheese);
            return Redirect("/Cheese");
        }
        

        
    }
}
