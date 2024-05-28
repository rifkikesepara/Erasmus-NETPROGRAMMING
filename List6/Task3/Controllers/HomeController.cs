using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task3.Models;

namespace Task3.Controllers
{
    public class HomeController : Controller
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
        public IActionResult GenerateNumbers(NumbersViewModel model)
        {
            Console.WriteLine(model.Max);

            if (model.Max - model.Min < 100)
            {
                ModelState.TryAddModelError("Gap Error", "Between the beginning and end of the range must be at least 100 integers");
                return View("Index");
            }
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            Random random = new Random();
            List<int> numbers= new List<int>();
            List<int> nonrepeat= new List<int>();
            SortedDictionary<int,int> counts= new SortedDictionary<int, int>();

            for (int i = 0; i < model.Amount; i++)
            {
                int number = 0;
                do
                {
                    number = random.Next(model.Min, model.Max);
                    numbers.Add(number);
                    if (counts.ContainsKey(number)) counts[number]++;
                    else counts.Add(number, 1);
                } while (nonrepeat.Contains(number));
                nonrepeat.Add(number);
            }
            model.GeneratedNumbers = numbers;
            model.NonRepeatedNumbers = nonrepeat;
            model.RepetationNumbers = counts;
            return View("Index", model);
        }

        public IActionResult Numbers(NumbersViewModel model)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            for(int i=0;i<100;i++)
            {
                numbers.Add(random.Next(model.Min,model.Max));
            }
            //Console.WriteLine(Repository.users[0].Name);
            return View(numbers);
        }
    }
}
