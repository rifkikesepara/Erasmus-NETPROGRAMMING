using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task4.Models;

namespace Task4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Cart.items.Clear();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddToCart(CartViewModel model)
        {
            Console.WriteLine("debug");
            Cart.AddProduct(model);
            return View("Index");
        }

        public IActionResult RemoveFromCart(CartViewModel model)
        {
            Console.WriteLine("Quantity: "+model.Quantity);
            Cart.RemoveProduct(model);
            return View("Index");
        }

        [HttpPost]
        public IActionResult Result(string Payment,string shipmentAddress) {
            List<string> sale = new List<string>();
            sale.Add(Payment);
            sale.Add(shipmentAddress);
            return View("Result",sale);
        }
        public IActionResult BuyTheProducts() { return View("Payment"); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
