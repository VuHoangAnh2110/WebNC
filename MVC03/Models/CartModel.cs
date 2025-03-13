using System;

namespace MVC03.Models
{
    public class CartModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
