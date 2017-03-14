using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class MainCLass
    {
        public static void Main(string[] args)
        {
            var items = new InterfaceItem[]
            {
            new Film("Adams Aepfel", 5.99, 2005),
            new Film("Headhunters", 9.99, 2011),
            new Film("In China essen sie Hunde", 2.99, 1999),
            new Season("Archer", 1, 7.90, 2009),
            new Season("Futurama", 1, 4.90, 1999),
            new Season("Westworld", 1, 19.90, 2016),
            };

            /*Alle Elemente aus items ausgeben*/
            foreach (var element in items)
            {
                Console.WriteLine(" {0} | {1} | {2} EUR", element.Title, element.Release_year, element.GetPrice());
            }

            /*Price ändern*/
            foreach (var element in items)
            {
                element.UpdatePrice(1.99);
            }

            /*Sale! $$$*/
            Console.WriteLine("---Abverkauf! Alle Filme und Serien nur 1.99 EUR!---");

            /*nochmal foreach ausgeben */
            foreach (var element in items)
            {
                Console.WriteLine(" {0} | {1} | {2} EUR", element.Title, element.Release_year, element.GetPrice());
            }
        }
    }
}