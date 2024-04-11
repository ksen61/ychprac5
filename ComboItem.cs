using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop7
{
    internal class ComboItem
    {
        public int id { get; set; }
        public string Value { get; set; }

        public ComboItem(int id, string value)
        {
            this.id = id;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
