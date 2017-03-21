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
            var items = new Film[]
            {
            new Film("Adams Aepfel", 5.99, 2005),
            new Film("Headhunters", 9.99, 2011),
            new Film("In China essen sie Hunde", 2.99, 1999),
            };

            /*Alle Elemente aus items ausgeben*/
            foreach (var element in items)
            {
                Console.WriteLine(" {0} | {1} | {2} EUR", element.Title, element.Release_year, element.GetPrice());
            }

            //Ab hier:
            var xitems = new DeserealizedObject[]
            {
            new DeserealizedObject("Adams Aepfel", 2005),
            new DeserealizedObject("Headhunters", 2011),
            new DeserealizedObject("In China essen sie Hunde", 1999),
            };

            foreach (var element in xitems)
            { 
                Console.WriteLine(" {0} | {1}", element.Title, element.Release_year);
            }
            /*
            string xy = "TestText";
            Directory.CreateDirectory(@"C:\temp");
            File.WriteAllText(@"C:\temp\WriteText.txt", xy);
            string content = File.ReadAllText(@"C:\temp\WriteText.txt");
            Console.WriteLine(content);
            */

            /*Alle Obhjekte aus dem Array "items" zu "json" serializieren*/
           // string json = JsonConvert.SerializeObject(items);

            /*JSON File erstellen*/
            //Directory.CreateDirectory(@"C:\temp");
            //File.WriteAllText(@"C:\temp\WriteText.json", json);


            /*JSON String erstellen aus dem Array xitems*/
            string json = JsonConvert.SerializeObject(xitems);

            /*JSON string in .json file abspeichern "serealisieren/write"*/
            Directory.CreateDirectory(@"C:\temp");
            File.WriteAllText(@"C:\temp\WriteText.json", json);

            /*JSON File in String abspeichern "deserealisieren/read"*/
            string content = File.ReadAllText(@"C:\temp\WriteText.json");

            Console.WriteLine(content);

            /*Deserealisierung aus dem JSON string "content"*/
            List<DeserealizedObject> jsonobject = JsonConvert.DeserializeObject<List<DeserealizedObject>>(content);

            /*Ausgabe des jsonobject arrays*/
            foreach (var element in jsonobject)
            {
                Console.WriteLine(" {0} | {1}", element.Title, element.Release_year);
            }
        }
    }
}
