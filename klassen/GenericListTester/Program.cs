using System;
using System.Collections.Generic;

namespace GenericListTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> tempList = new List<string>() { "a", "v", "b", "s", "f", "g" };
            //ListTester<string> thisList = new ListTester<string>(tempList);
            //thisList.PrintList();
            //thisList.Delete("g");
            //thisList.Add("q");
            //thisList.ShowItem(4);
            //Console.WriteLine(thisList.ToString());
            //thisList.PrintList();
            List<Student> tempList = new List<Student>() { new Student("Jos","A3",17), new Student("Jef", "A3", 17) };
            ListTester<Student> thisList = new ListTester<Student>(tempList);
            thisList.PrintList();
            thisList.EditStudent<string>(0, "Name", "Vincent");
            thisList.EditStudent<int>(0, "Age", 23);
            Console.WriteLine();
            thisList.PrintList();
        }
    }
}
