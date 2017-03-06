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
                new Dvd("Adams Aepfel", 5.90, 2005),
                new Dvd("Headhunters", 9.90, 2011),
                new Dvd("In China essen sie Hunde", 2.90, 1999),
            };

            foreach (var element in dvds)
            {/*Price fixen in Klasse*/
                Console.WriteLine(" {0} | {1} | {2} EUR", element.Title, element.Release_year, element.Price);
            }
            /*Price ändern*/
            /*nochmal foreach ausgeben */
        }
    }
}
