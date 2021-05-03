using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListTester
{
    class ListTester<T>
    {

//PT2: Maak dit mogelijk voor objecten.Stel dat ik een lijst v studenten heb wil ik voor
//elke specifieke student in de lijst de waardes kunnen aanpassen.
//(ik selecteer een student en bewerk deze)
        public List<T> MyList { get; private set; }
        public ListTester(List<T>inputList)
        {
            MyList = inputList;
        }
        public void PrintList()
        {
            for (int i = 0; i < MyList.Count; i++)
            {
                Console.WriteLine($"item {i+1} " + MyList[i].ToString());
            }
        }
        public override string ToString()
        {
            Type typeParameterType = typeof(T);
            return $"This list consists of {MyList.Count} {typeParameterType}'s";
        }
        public void Add(T toAdd)
        {
            MyList.Add(toAdd);
            Console.WriteLine($"Added {toAdd}");
        }
        public void ShowItem(int index)
        {
            if (index > MyList.Count)
            {
                Console.WriteLine("Index out of bounds");
            }
            else
            {
                Console.WriteLine($"item {index} "+ MyList[index].ToString());
            } 
        }
        public void Delete(T toDelete)
        {
            foreach (var item in MyList)
            {
                if (item.Equals(toDelete))
                {
                    MyList.Remove(item);
                    Console.WriteLine($"Removed {item}");
                    return;
                }
            }
        }
        public void EditStudent<S>(int index, string property, S newValue)
        {
            if (MyList[index].GetType().GetProperty(property) != null)
            {
                MyList[index].GetType().GetProperty(property).SetValue(MyList[index], newValue);
            }
            else
            {
                Console.WriteLine("This object has no such property");
            }
        }
    }
}
