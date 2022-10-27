using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    internal class Order
    {
        internal int OrderId;
        internal string OrderName;
        internal DateTime OrderDate;
        internal int OrderQuantity;

        public Order(int orderId, string orderName, DateTime orderDate, int orderQuantity)
        {
            OrderId = orderId;
            OrderName = orderName;
            OrderDate = orderDate;
            OrderQuantity = orderQuantity;
        }

        



        


    }
}
