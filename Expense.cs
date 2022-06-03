using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE
{
   public abstract class Expense
    {
        //Variables for the expensive class
        List<double> lstExpenses = new List<double>();
        List<string> lstExpensesNames = new List<string>()
        {
            "Groceries:", "Water and lights:","Travel costs:", "Cellphone and telephone:",
            "Other expenses:"
        };
        
        public double availableMoney;
        public double income;
        public double deposit;
        public double interest;
        public double months;

        public List<double> LstExpenses { get => lstExpenses; set => lstExpenses = value; }
        public List<string> LstExpensesNames { get => lstExpensesNames; set => lstExpensesNames = value; }

        public delegate string checkExpenses(double moneyAvailable, double income);
        public static string delCheckExpenses(double moneyAvailable, double income)
        {
            string strOutput = "";
            if (moneyAvailable < (income * 0.25))
            {
                strOutput += "Expenses exceed 75% of income";
            }
            return strOutput;
        }
        //Methods that are to be overrided in child classes
        public abstract void calculate(double price);
        public abstract void sortExpense();
        public abstract string ToString();
    }
}




    


