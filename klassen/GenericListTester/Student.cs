using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListTester
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public Student(string naam, string klas, int leeftijd)
        {
            Name = naam;
            Class = klas;
            Age = leeftijd;
        }
        public override string ToString()
        {
            return $"{Name} is {Age} years old, and is in class {Class}";
        }
    }
}
