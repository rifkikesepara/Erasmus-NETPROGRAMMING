namespace Task4.Models
{
    public static class Products
    {
        static Products()
        {
            list.Add(new ProductViewModel { Id = 0, Name = "Choclate", Price = 20, StockLevel = 100 });
            list.Add(new ProductViewModel { Id = 1, Name = "Gum", Price = 5, StockLevel = 20 });
            list.Add(new ProductViewModel { Id = 2, Name = "Chips", Price = 15, StockLevel = 500 });
            list.Add(new ProductViewModel { Id = 3, Name = "Cookies", Price = 30, StockLevel = 78 });
            list.Add(new ProductViewModel { Id = 4, Name = "Biscuits", Price = 10, StockLevel = 124 });
        }

        public static List<ProductViewModel> list=new List<ProductViewModel>();
    }
}
