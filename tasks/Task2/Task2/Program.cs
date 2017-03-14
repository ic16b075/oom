using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MainCLass
    {
        public static void Main(string[] args)
        {
            var dvds = new[]
            {
                new Dvd("Adams Aepfel", 5.99, 2005),
                new Dvd("Headhunters", 9.99, 2011),
                new Dvd("In China essen sie Hunde", 2.99, 1999),
            };

            foreach (var element in dvds)
            {
                Console.WriteLine(" {0} | {1} | {2} EUR", element.Title, element.Release_year, element.GetPrice());
            }
            /*Price ändern*/
            foreach (var element in dvds)
            {
                element.UpdatePrice(1.99);
            }
            /*nochmal foreach ausgeben */
            foreach (var element in dvds)
            {
                Console.WriteLine(" {0} | {1} | {2} EUR", element.Title, element.Release_year, element.GetPrice());
            }
        }
    }
}
