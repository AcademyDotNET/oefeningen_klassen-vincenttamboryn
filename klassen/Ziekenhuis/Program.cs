using System;

namespace Ziekenhuis
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient henk = new Patient();
            henk.name = "henk";
            henk.hoursInTheHospital = 5;
            henk.ToonInfo();

            InsuredPatient bart = new InsuredPatient();
            bart.name = "bart";
            bart.hoursInTheHospital = 10;
            bart.ToonInfo();
        }
    }
}
