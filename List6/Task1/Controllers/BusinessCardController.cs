using MeetingApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task1.Models;

namespace Task1.Controllers
{
    public class BusinessCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GenerateBusinessCard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateBusinessCard(BusinessCardViewModel model)
        {
            Console.WriteLine(model.Name);
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                return View("Index", model);
            }

            // Generate the business card (customize this logic)
            // Save or display the business card as needed
            Repository.CreateUser(model);
            return View("List", model);
        }

        public IActionResult List(BusinessCardViewModel model)
        {
            //Console.WriteLine(Repository.users[0].Name);
            return View(model);
        }
    }
}
