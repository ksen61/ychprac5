using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop7
{
    internal class WarehouseModel
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string Delivery_Date { get; set; }
        public int Suppliers_ID { get; set; }
    }
}