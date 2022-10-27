using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            int[] a = { 23, 120, 525, 1002, 53, 12, 85 };
            var query = from x in a
                        where x > 100 && x < 1000
                        select x * x * x;
            foreach (var y in query)
            {
                Console.WriteLine(y);
            }

            //3
            LinqQueries Lq = new LinqQueries();
            List<Order> l=Lq.InitializeList();
            Lq.OrderSort(l);
            Lq.OrderGroup(l);
            //4
            List < Item > L1= Lq.InitializeItemList();
            Lq.OrderPrice(l, L1);

            Lq.Queries(l);


        }
        
        }
    }