using System;
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

            // Start of Lesson 6.1:
            // IObservable: represents a producer of values
            // IObserver represents a consumer of values

            // create new 'producer' (IObservable) of type InterfaceItem
            var producer = new Subject<InterfaceItem>();
            // subscribe to producer
            producer.Subscribe(x => Console.WriteLine($"received value {x}"));

            // iterate over Array items which contains variables/interfaces of type InterfaceItem
            foreach (var element in items)
            {
                // simulate a push of IObservable to subscriber every 1 second
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                producer.OnNext(element); // push an element to subscriber
            }

            // Start of Lesson 6.2:
            /*Wie kann ich Task 6.1 einbauen um parallel zur Primzahlenrechnung zu laufen?*/

            var random = new Random();

            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var tasks = new List<Task<int>>();

            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {
                    WriteLine($"computing result for {x}");
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait();
                    WriteLine($"done computing result for {x}");
                    return x * x;
                });

                tasks.Add(task);
            }

            WriteLine("doing something else ...");

            var tasks2 = new List<Task<int>>();
            foreach (var task in tasks.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(t => { WriteLine($"result is {t.Result}"); return t.Result; })
                );
            }

            var cts = new CancellationTokenSource();
            var primeTask = ComputePrimes(cts.Token);

            ReadLine();
            cts.Cancel();
            WriteLine("canceled ComputePrimes");

            ReadLine();



            /*
            Console.WriteLine("Shows use of Start to start on a background thread:");
            var o = Observable.Start(() =>
            {
                //This starts on a background thread.
                Console.WriteLine("From background thread. Does not block main thread.");
                Console.WriteLine("Calculating...");
                Thread.Sleep(3000);
                Console.WriteLine("Background work completed.");
            }).Finally(() => Console.WriteLine("Main thread completed."));
            Console.WriteLine("\r\n\t In Main Thread...\r\n");
            o.Wait();   // Wait for completion of background operation.
            */
            WriteLine("End");




        }
        public static Task<bool> IsPrime(int x, CancellationToken ct)
        {
            return Task.Run(() =>
            {
                for (var i = 2; i < x - 1; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    if (x % i == 0) return false;
                }
                return true;
            }, ct);
        }

        public static async Task ComputePrimes(CancellationToken ct)
        {
            for (var i = 100000000; i < int.MaxValue; i++)
            {
                ct.ThrowIfCancellationRequested();
                if (await IsPrime(i, ct)) WriteLine($"prime number: {i}");
            }
        }
    }
}
