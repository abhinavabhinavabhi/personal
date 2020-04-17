using Apache.Ignite.Core.Cache.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igniteSQL
{
    class Person
    {
        [QuerySqlField]
        public String Name { get; set; }
        [QuerySqlField]
        public int Age { get; set; }
        [QuerySqlField]
        public int oid { get; set; }
        //public override string ToString()
        //{
        //    return $"Person [name={Name} ,Age= {Age}]";
        //}
    }
}
