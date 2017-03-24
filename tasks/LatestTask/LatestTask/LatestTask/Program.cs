using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LatestTask
{
    class MainCLass
    {
        public static void Main(string[] args)
        {
            var items = new InterfaceItem[]
            {
            new Film("Adams Aepfel", 5.99, 2005, true),
            new Film("Headhunters", 9.99, 2011, true),
            new Film("In China essen sie Hunde", 2.99, 1999, true),
            new Season("Archer", 1, 7.90, 2009, true),
            new Season("Futurama", 1, 4.90, 1999, true),
            new Season("Westworld", 1, 19.90, 2016, true),
            };

            /*Alle Elemente aus items ausgeben*/
            foreach (var element in items)
            {
                Console.WriteLine(" {0} | {1} | {2} EUR", element.Title, element.Release_year, element.Price);
            }

            /*Price ändern*/
/*            foreach (var element in items)
            {
                element.UpdatePrice(1.99);
            }
*/
            /*Sale! $$$*/
//            Console.WriteLine("---Abverkauf! Alle Filme und Serien nur 1.99 EUR!---");

            /*nochmal foreach ausgeben */
/*            foreach (var element in items)
            {
                Console.WriteLine(" {0} | {1} | {2} EUR", element.Title, element.Release_year, element.GetPrice());
            }
*/
            /*Lesson 4: Serialization*/
            var serialized = items[0];

            // serialize a single film/series to a JSON string with formatting
            Console.WriteLine(JsonConvert.SerializeObject(serialized, Formatting.Indented));

            // serialize all items 
            // & include type, so we can deserialize sub-classes to interface type */
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(items, settings));

            // store json string to file "items.json" on your Desktop
            var text = JsonConvert.SerializeObject(items, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items1.json");
            File.WriteAllText(filename, text);

            // deserialize items from "items.json"
            // ... and print Description and Price of deserialized items
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<InterfaceItem[]>(textFromFile, settings);
            foreach (var x in itemsFromFile)
                Console.WriteLine(" {0} | {1} | {2} EUR", x.Title, x.Release_year, x.Price);

        }
    }
}
