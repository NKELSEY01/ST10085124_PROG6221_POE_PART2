using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE
{
    class HomeLoan : Expense
    {
        //variables stored in the homeloan class
        double totalLoan;
        double monthlyPayment = 0;
        public override void calculate(double price)
        {
            //the money is equal to the income the person receive each month
            availableMoney = income;

            //how the calculations needs to be done
            foreach (double e in LstExpenses)
            {
                //all the expenses is pulled off the money that is available
                availableMoney -= e;
            }

            //calculation for the interest when the buy option is chosen
            totalLoan = (price - deposit) * (1 + interest * (months / 12));
            //the total moeny that is been loan divide by the total months is equal to the monthly payment
            monthlyPayment = (totalLoan / months);
            //money available is minus expenses and the monthly payment
            availableMoney -= monthlyPayment;

            LstExpenses.Add(Math.Round(monthlyPayment, 2));
            LstExpensesNames.Add("Monthly Home Loan Payments:");
            sortExpense();
        }

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
        //method to show how the out must be structered when the program is being executed for the awnser
        public override string ToString()
        {
            checkExpenses handler = delCheckExpenses;
            String strOutput = ("Income: R" + Math.Round(income, 2));
            strOutput += "\n------------------------------------------\n";
            strOutput += "Expenses:\n\n";
            for (int x = 0; x < LstExpenses.Count; x++)
            {
                strOutput += (LstExpensesNames[x] + " \tR" + LstExpenses[x] + "\n");
            }
            strOutput += "------------------------------------------";
            strOutput += "\nMoney available = R" + Math.Round(availableMoney, 2);
            strOutput += "\n------------------------------------------\n";
            strOutput += handler(availableMoney, income);

            if (monthlyPayment > (income * 0.33))
            {
                strOutput += "\nYour home loan approval is unlikely";
            }

            return strOutput;
        }
    }
}
