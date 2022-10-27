using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    internal class Item
    {
        internal string ItemName;
        internal int Price;

        public Item(string itemName, int price)
        {
            ItemName = itemName;
            Price = price;
        }   
    }
}
