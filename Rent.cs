using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE
{
    class Rent : Expense
    {
        //calculate method for the rent
        public override void calculate(double price)
        {
            availableMoney = income - price;
            foreach (double e in LstExpenses)
            {
                availableMoney -= e;
            }
            LstExpenses.Add(price);
            LstExpensesNames.Add("Rent:");
            sortExpense();
        }

        //method to show the output
        public override void sortExpense()
        {
            double tempValue;
            string tempName;

            for (int x = 0; x < LstExpenses.Count - 1; x++)
            {
                for (int y = 0; y < LstExpenses.Count - 1; y++)
                {
                    if (LstExpenses[y] < LstExpenses[y + 1])
                    {
                        tempValue = LstExpenses[y + 1];
                        tempName = LstExpensesNames[y + 1];
                        LstExpenses[y + 1] = LstExpenses[y];
                        LstExpensesNames[y + 1] = LstExpensesNames[y];
                        LstExpenses[y] = tempValue;
                        LstExpensesNames[y] = tempName;
                    }
                }
            }
        }

        //Method returns a string for output
        public override string ToString()
        {
            checkExpenses handler = delCheckExpenses;
            String strDisplay = ("Income: R" + Math.Round(income, 2));
            strDisplay += "\n------------------------------------------\n";
            strDisplay += "Expenses:\n\n";
            for (int x = 0; x < LstExpenses.Count; x++)
            {
                strDisplay += (LstExpensesNames[x] + " \tR" + LstExpenses[x] + "\n");
            }
            strDisplay += "------------------------------------------";
            strDisplay += "\nMoney available = R" + Math.Round(availableMoney, 2);
            strDisplay += handler(availableMoney, income);
            return strDisplay;

        }

    }
}
