using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    internal class LinqQueries
    {
        public List<Order> InitializeList()
        {
            Order O1 = new Order(1, "Choclates",new DateTime(2001,01,31), 5);
            Order O2 = new Order(2, "Books",new DateTime(1997,03,05), 4);
            Order O3 = new Order(3, "Pens", new DateTime(1975,07,01), 6);
            Order O4 = new Order(4, "Pencils", new DateTime(2001, 01, 31),7);
            List<Order> L = new List<Order>();
            L.Add(O1);
            L.Add(O2);
            L.Add(O3);
            L.Add(O4);
            return L;
        }
        public void OrderSort(List<Order> l)
        {
            var query1 = from o in l
                         orderby o.OrderDate descending, o.OrderQuantity descending
                         select o;
            foreach (var y in query1)
            {
                Console.WriteLine($"{y.OrderName} - {y.OrderDate} -{y.OrderQuantity}");
            }
        }
     
        public void OrderGroup(List<Order> l)
        {
            var query2 = from o in l
                         orderby o.OrderDate descending
                         group o by o.OrderDate.Month into g
                         select g;
            Console.WriteLine("query2");

            foreach (var y in query2)
            {
                foreach(var x in y)
                Console.WriteLine($"{x.OrderName} - {x.OrderDate} -{x.OrderQuantity}");
            }
        }
        public List<Item> InitializeItemList()
        {
            Item I1 = new Item("Choclates", 5);
            Item I2 = new Item("Books", 3);
            Item I3 = new Item("Pens", 4);
            Item I4 = new Item("Pencils", 2);
            List<Item> L = new List<Item>();
            L.Add(I1);
            L.Add(I2);
            L.Add(I3);
            L.Add(I4);
            return L;
        }
        public void OrderPrice(List<Order> O, List<Item> I)
        {
            var query3 = from o in O
                         join i in I on o.OrderName equals i.ItemName
                         select new
                         {
                             OrderId = o.OrderId,
                             ItemName = i.ItemName,
                             OrderDate = o.OrderDate,
                             TotalPrice = o.OrderQuantity * i.Price
                         };
            Console.WriteLine("query3");
            foreach (var y in query3)
            {
                Console.WriteLine($"{y.ItemName} - {y.OrderDate} -{y.TotalPrice}");
            }

        }
      /*  public void AnonymousPrice(List<Order> O, List<Item> I)
        {
            var query4 = from o in O
                         group o by new
                         {

                         }

        }*/
        public void Queries(List<Order> o)
        {
            var q5 = o.Where(a => a.OrderQuantity > 0);
            Console.WriteLine("query5");
            foreach (var y in q5)
            {
                Console.WriteLine($"{y.OrderName} ");
            }

            var q6 = o.OrderByDescending(a => a.OrderQuantity).Take(1);
            Console.WriteLine("query6");
            foreach (var y in q6)
            {
                Console.WriteLine($"{y.OrderName} ");
            }
            int year = DateTime.Now.Year;
            var q7= o.Where(a=>a.OrderDate.Month > 1 && a.OrderDate.Year < year);
            Console.WriteLine("query7");
            foreach (var y in q7)
            {
                Console.WriteLine($"{y.OrderName} - {y.OrderDate} ");
            }
            int[] a = { 2,3,4,5,6};
            int q8 = a.Where(a => a % 2 == 0).Count();
            Console.WriteLine(q8);
            
        }
        public void SumOrders(List<Order> O)
        {

            var query8 = from o in O
                         group o by o.OrderName into g
                         select new Order{
                             OrderId=g.First().OrderId,
                             OrderName = g.First().OrderName,
                             OrderDate = g.First().OrderDate,
                             OrderQuantity = g.Sum(p => p.OrderQuantity),
                       };
            foreach(Order y in query8)
            {
                foreach (var x in y)
                    Console.WriteLine($"{x.OrderName} - {x.OrderDate} -{x.OrderQuantity}");
            }

        }
    }
}
