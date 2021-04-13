using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime
{
    class Pizza
    {
        private string toppings;
        private int diameter;
        private double price;
        public string Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                if (value != "")
                    toppings = value;
            }
        }
        public int Diameter
        {
            get
            {
                return diameter;
            }
            set
            {
                if (value > 0 && Microsoft.VisualBasic.Information.IsNumeric(value))
                    diameter = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0 && Microsoft.VisualBasic.Information.IsNumeric(value))
                    price = value;
            }
        }
    }
}
