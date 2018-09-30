using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingDojo1.Test
{
    class TestObject
    {
        public int Age { get; set; }
        public string Name { get; set; }


        public TestObject(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public override string ToString()
        {
            return String.Format("{0} : {1}", Name, Age);
        }
    }
}
