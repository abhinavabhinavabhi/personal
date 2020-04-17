using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;

namespace igniteSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var conf = new IgniteConfiguration
            {
                BinaryConfiguration = new BinaryConfiguration(typeof(Person), typeof(Organization))
            };
            Environment.SetEnvironmentVariable("IGNITE_H2_DEBUG_CONSOLE", "true");
            IIgnite ignite = Ignition.Start(conf);
            //scan query
            //ICache<int, Person> cache = ignite.GetOrCreateCache<int, Person>( "persondet");
            //cache[1] = new Person { Name = "Abhinav", Age = 21 };
            //cache[2] = new Person { Name = "amal", Age = 13 };
            //cache[3] = new Person { Name = "sujina", Age = 33 };
            //cache[4] = new Person { Name = "rajeevan", Age = 43 };

            //var scanQuery = new ScanQuery<int, Person>(new Personfilter());

            //IQueryCursor<ICacheEntry<int, Person>> querycur = cache.Query(scanQuery);


            ICache<int, Person> percache = ignite.GetOrCreateCache<int, Person>(new CacheConfiguration("persons", typeof(Person)));
            ICache<int, Organization> orgcache = ignite.GetOrCreateCache<int, Organization>(new CacheConfiguration("orgs", typeof(Organization)));

            percache[1] = new Person { Name = "Abhinav", Age = 21 ,oid=1};
            percache[2] = new Person { Name = "amal", Age = 13 ,oid=2};
            percache[3] = new Person { Name = "sujina", Age = 33 ,oid=1};
            percache[4] = new Person { Name = "rajeevan", Age = 43 ,oid=2};

            orgcache[1] = new Organization { id = 1, name = "Google" };
            orgcache[2] = new Organization { id = 2, name = "Facebook" };

            //sql Query
            //var sqlquery = new SqlQuery(typeof(Person), "where age > ?", 30);

            //select using query fields
            //SqlFieldsQuery sqquery = new SqlFieldsQuery("select name from Person where age>?", 30);
            //foreach(IList fields in querycur)
            //{
            //    Console.WriteLine(fields[0]);
            //}
            var sqlque = new SqlFieldsQuery("select Person.Name , Person.Age from Person " +
                "join\"orgs\".Organization as org on(Person.oid=org.id)" +
                "where org.name=?","Google");
            //IQueryCursor<IList> querycur = cache.QueryFields(sqlque);


            //Console.WriteLine(querycur.GetAll()[0][0]);

            foreach (var fieldlist in percache.QueryFields(sqlque))
            {
                Console.WriteLine(fieldlist[0]+"  "+fieldlist[1]);
            }

            Console.ReadKey();
        }
    }
}
