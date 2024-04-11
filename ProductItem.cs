using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop7
{
    internal class ProductItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int Quantity { get; set; }

        public ProductItem(int id, string name, double price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.Quantity = quantity;
        }
    }
}
