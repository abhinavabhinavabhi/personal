using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Ignite.Core.Cache.Configuration;

namespace igniteSQL
{
    class Organization
    {
        [QuerySqlField]
        public string name { get; set; }
        [QuerySqlField]
        public int id { get; set; }
    }
}
