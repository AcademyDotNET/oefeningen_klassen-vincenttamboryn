using System;
using System.Collections.Generic;

namespace StudentKlasse
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            student1.Klas = Student.Klassen.EA2;
            student1.Leeftijd = 21;
            student1.Naam = "Joske Vermeulen";
            student1.PuntenCommunicatie = 12;
            student1.PuntenProgrammingPrinciples = 15;
            student1.PuntenWebTech = 13;

            //student1.GeefOverzicht();

            List < Student >studenten = new List<Student>() { student1, new Student("Jeff"), new Student("Ben"), new Student("Bob"), new Student("Bart") };
            Menu(studenten);

        }
        static void Menu(List<Student>studentenlijst)
        {
            Console.WriteLine("What would you like to do?\n1. Enter student information.\n2. View student information.\n3. Exit the program.");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ChangeStudents(studentenlijst);
                    break;
                case "2":
                    ShowStudents(studentenlijst);
                    break;
                case "3":
                    return;
                default:
                    Menu(studentenlijst);
                    return;
            }
            Menu(studentenlijst);
        }
        static void ShowStudents(List<Student> studentenlijst)
        {
            for (int i = 0; i < studentenlijst.Count; i++)
            {
                if (studentenlijst[i] != null)
                {
                    studentenlijst[i].GeefOverzicht();
                }
            }
        }
        static void ChangeStudents(List<Student> studentenlijst)
        {
            Console.WriteLine($"Which student would you like to change?\n1. {studentenlijst[0].Naam} \n2. {studentenlijst[1].Naam} \n3. {studentenlijst[2].Naam} \n4. {studentenlijst[3].Naam}\n5. {studentenlijst[4].Naam}\n6. No student");
            string input = "";
            try
            {
                input = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                input = "a";
            }
            switch (input)
            {
                case "1":
                    ChangeData(studentenlijst[0]);
                    break;
                case "2":
                    ChangeData(studentenlijst[1]);
                    break;
                case "3":
                    ChangeData(studentenlijst[2]);
                    break;
                case "4":
                    ChangeData(studentenlijst[3]);
                    break;
                case "5":
                    ChangeData(studentenlijst[4]);
                    break;
                case "6":
                    return;
                default:
                    ChangeStudents(studentenlijst);
                    return;
            }
        }
        static void ChangeData(Student student)
        {
            Console.WriteLine("What would you like the name of this student to be?");
            student.Naam = Console.ReadLine();
            try
            {
                student.Leeftijd = Convert.ToInt32(GiveNumber("int", "How old is this student?", 0, 150));
                student.PuntenCommunicatie = Convert.ToInt32(GiveNumber("int", "Marks on Communitcation?", 0, 100));
                student.PuntenProgrammingPrinciples = Convert.ToInt32(GiveNumber("int", "Marks on Programming Principles?", 0, 100));
                student.PuntenWebTech = Convert.ToInt32(GiveNumber("int", "Marks on Web Technologies?", 0, 100));
                int whichClass = Convert.ToInt32(GiveNumber("int", $"In which class is {student.Naam}?\n1 for EA1, 2 for EA2, 3 for EA3, 4 for EA4, 5 for EA5, 6 for EA6", 1, 6));
                student.Klas = (Student.Klassen)whichClass;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                student.Leeftijd = 16;
                student.PuntenCommunicatie = 60;
                student.PuntenProgrammingPrinciples = 60;
                student.PuntenWebTech = 60;
                student.Klas = Student.Klassen.EA1;
            }
            
        }
        static double GiveNumber(string test, string question, double minValue = double.NegativeInfinity, double maxvalue = double.PositiveInfinity)
        {
            string numberString;
            do
            {
                Console.WriteLine(question);
                numberString = Console.ReadLine();
            } while (!(Microsoft.VisualBasic.Information.IsNumeric(numberString)));
            double number = Convert.ToDouble(numberString);
            if (number < minValue || number > maxvalue)
            {
                return GiveNumber(test, question, minValue, maxvalue);
            }
            else
            {
                if (test == "+")
                {
                    if (number >= 0)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("+", question, minValue, maxvalue);
                        return number;
                    }
                }
                else if (test == "-")
                {
                    if (number < 0)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("+", question, minValue, maxvalue);
                        return number;
                    }
                }
                else if (test == "int")
                {
                    char[] komma = { ',' };
                    if (numberString.IndexOfAny(komma) == -1)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("int", question, minValue, maxvalue);
                        return number;
                    }
                }
                else
                {
                    return number;
                }
            }

        }
    }
}
