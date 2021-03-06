﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using static System.Console; //needed for: WriteLine("somestring");

namespace LatestTask
{
    class MainCLass
    {
        public static void Main(string[] args)
        {
            // Asynchrone Methode
            AsyncWithAwait();
            // Background Task
            Task.Run(() => AsyncWithOutAwait());

            //--------------------------------------------------------------

            //Synchroner Programmablauf
            var items = new InterfaceItem[]
            {
            new Film("Adams Aepfel", 5.99, 2005, false),
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
            //---------------------------------------------------------------
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

            //-------------------------------------------------------------
            // Lesson 6.1:
            // IObservable: represents a producer of values
            // IObserver represents a consumer of values

            // create new 'producer' (IObservable) of type InterfaceItem
            var producer = new Subject<InterfaceItem>();
            // subscribe to producer
            producer.Subscribe(x => Console.WriteLine($"received value {x.Price}"));

            // iterate over Array items which contains variables/interfaces of type InterfaceItem
            foreach (var element in items)
            {
                // simulate a push of IObservable to subscriber every 1 second
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                producer.OnNext(element); // push an element to subscriber
            }

            //----------------------------------------------------------
            // Synchroner Ablauf bevor das Programm beendet
            // damit asynchrone Abläufe genug Zeit haben um noch ausgeführt zu werden
            WriteLine("Beliebige Eingabe: ");
            string wort = Console.ReadLine();
            WriteLine("Eingabe war: {0}", wort);
            WriteLine("Synchrones Main-Programm-Ende.");



        }
        //Lesson 6.2

        //Tipp: Task.Run ist sinvoll CPU-bound Tasks
        public static void AsyncWithOutAwait()
        {
            Thread.Sleep(3000);
            Console.WriteLine(">>> Task.Run Ausgabe! <<<");
        }
        //Tipp: Async mit Await ist sinvoll bei IO-bound Tasks
        public static async Task AsyncWithAwait()
        {
            // awaitable wird asynchron abgewartet
            // danach wird die asynchrone Funktion synchron weiter durchlaufen
            await Task.Delay(5000);
            Console.WriteLine("--- AsyncAwait Ausgabe! ---");
        }
    }
}
