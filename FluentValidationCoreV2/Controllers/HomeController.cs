using FluentValidationCoreV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentValidationCoreV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {

            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return View("Create", person);
            }

            Save(person); //Save the person to the database, or some other logic

            TempData["notice"] = "Person successfully created";
            return RedirectToAction("Index");

        }

        private void Save(Person person)
        {

        }
    }
}
