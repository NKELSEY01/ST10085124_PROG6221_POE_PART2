using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE
{
    class BuyCar : HomeLoan
    {
        //variables that are required for the buy a car class
        double totalLoan;
        double monthlyPayment = 0;
        double insurance;
        string make;
        string model;

        //get and set methods for each variable
        public double Insurance { get => insurance; set => insurance = value; }
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }

        //calculate method to get monthly car repayments
        public override void calculate(double price)
        {
            totalLoan = (price - deposit) * (1 + interest * (months / 12));
            monthlyPayment = ((totalLoan / months) + Insurance);
            availableMoney -= monthlyPayment;

            LstExpenses.Add(Math.Round(monthlyPayment, 2));
        }
    }
}

