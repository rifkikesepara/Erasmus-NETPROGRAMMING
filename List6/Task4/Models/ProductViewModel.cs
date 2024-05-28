using System.ComponentModel.DataAnnotations;

namespace Task4.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockLevel { get; set; }
    }
}
