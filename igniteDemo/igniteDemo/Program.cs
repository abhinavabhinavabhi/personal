using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;

namespace igniteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //cache Demo 

            //IIgnite ignt= Ignition.Start();
            // ICache<string, string> cache = ignt.GetOrCreateCache<string, string>("test");
            // cache.Put("name", "abhinav rajiv");
            // Console.Clear();
            // Console.WriteLine(cache.Get("name"));
            // if (cache.PutIfAbsent("salary", "10000000"))
            //     Console.WriteLine("salary added to cache..\n");
            // else
            //     Console.WriteLine(cache.Get("salary"));


            var cfng = new IgniteConfiguration
            {
                BinaryConfiguration = new BinaryConfiguration(typeof(Person))
            };
            IIgnite ing = Ignition.Start();
            ICache<int, Person> cache = ing.GetOrCreateCache<int, Person>("personc");
            cache[1] = new Person { Name = "Abhinav", Age = 21 };
            cache[2] = new Person { Name = "Amal", Age = 13 };
            Console.Clear();
            foreach(ICacheEntry<int,Person> entry in cache)
            {
                Console.WriteLine(entry);
            }
            Console.ReadKey();
        }
    }
}
