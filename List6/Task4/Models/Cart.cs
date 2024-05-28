namespace Task4.Models
{
    public static class Cart
    {
        public static void AddProduct(CartViewModel cartViewModel)
        {
            Products.list[cartViewModel.ProductId].StockLevel -= cartViewModel.Quantity;
            int index = -1;
            for(int i=0;i<Cart.items.Count;i++)
            {
                if (items[i].ProductId == cartViewModel.ProductId)
                {
                    index = i;
                    break;
                }
            }
            if(index!=-1)
                items[index].Quantity += cartViewModel.Quantity;
            else
                items.Add(cartViewModel);
        }

        public static void RemoveProduct(CartViewModel cartViewModel)
        {
            Products.list[cartViewModel.ProductId].StockLevel += cartViewModel.Quantity;
            int index= -1;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ProductId == cartViewModel.ProductId)
                {
                    index = i;
                    break;
                }
            }

            if (index!=-1)
            items.RemoveAt(index);
        }


        public static int GetTotal()
        {
            int total = 0;
            foreach (var item in items)
            {
                total += (int)Products.list[item.ProductId].Price * item.Quantity;
            }
            return total;
        }

        public static List<CartViewModel> items = new List<CartViewModel>();
    }
}
