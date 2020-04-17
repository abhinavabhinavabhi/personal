using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igniteDemo
{
    class Person
    {
        public String  Name { get; set; }
        public int Age{ get; set; }
        public override string ToString()
        {
            return $"Person [name={Name} ,Age= {Age}]";
        }
    }
}
