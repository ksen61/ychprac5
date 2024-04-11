using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop7
{
    internal class Check
    {
        int ID;
        DateTime Date;
        double Pay;
        List<ProductItem> Product;

        public Check(int ID, DateTime Date, double Pay, List<ProductItem> Product)
        {
            this.ID = ID;
            this.Date = Date;
            this.Pay = Pay;
            this.Product = Product;
        }

        public void SaveToFile(string dir)
        {
            string path = $"{dir}\\Чек№{ID}.txt";

            List<string> lines = new List<string>();
            lines.Add("\t\tЗоомагазин Yes of кусь");
            lines.Add($"\tКассовый чек №{ID} от {Date}");
            lines.Add("");
            double Price = 0;
            foreach (var product in Product)
            {
                Price += product.price * product.Quantity;
                lines.Add($"\t{product.name}\t-\t{product.price} x {product.Quantity}");
            }
            lines.Add("");
            lines.Add($"Итого к оплате: {Price}");
            lines.Add($"Внесено: {Pay}");
            lines.Add($"Сдача: {Pay - Price}");

            File.WriteAllLines(path, lines.ToArray());
        }
    }
}
