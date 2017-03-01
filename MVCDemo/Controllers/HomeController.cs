using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string welcomeMessage = "";
            DateTime date = DateTime.Now;
            int hour = date.Hour;
            if (hour < 12)
                welcomeMessage = "Good Morning!";
            else if (hour < 18)
                welcomeMessage = "Good afternoon!";
            else
                welcomeMessage = "Good evening!";
            welcomeMessage += Environment.NewLine;
            welcomeMessage += "The time is " + String.Format("{0:t}", date) + " on " +
                String.Format("{0:dddd, MMMM d, yyyy}", date) ;
            DateTime nextYear = new DateTime(date.Year + 1, 1, 1);
            int DaysLeft = nextYear.Subtract(date).Days;
            welcomeMessage += Environment.NewLine;
            welcomeMessage += DaysLeft + " more days until " + date.Year + 1;
            ViewData["WelcomeMessage"] = welcomeMessage;
            return View();
        }
        public ActionResult ShowPerson()
        {
            Person person = new Person() { FirstName="Devash", LastName="Anandpara", DateOfBirth= new DateTime(1994, 13, 11)
                                          };
            ViewData["Person"] = person;
            return View(person);
        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                ViewData["Person"] = person;
                return View("ShowPerson", person);
            }
            else
                return View();
        }
    }
}