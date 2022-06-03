using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjPOE
{
    public partial class Form1 : Form
    {
        //Expenses is storedin an array 
        List<double> lstExpenses = new List<double>();
        double income, price, deposit, interest, months;
        //Variables that need to be stored in the form
        double carPrice, carDeposit, carInterest, insurance;
        string make, model;

        public Form1()
        {
            InitializeComponent();
        }

        //yes and no radio buttons for the buy a car option
        private void rbtYes_CheckedChanged(object sender, EventArgs e)
        {
            lblMake.Visible = true;
            txtMake.Visible = true;
            lblModel.Visible = true;
            txtModel.Visible = true;
            lblPurchasePrice.Visible = true;
            txtPurchasePrice.Visible = true;
            lblTotalDeposit.Visible = true;
            txtTotalDeposit.Visible = true;
            lblInterest.Visible = true;
            txtInterest.Visible = true;
            lblInsurancePremium.Visible = true;
            txtInsurancePremium.Visible = true;
        }

        private void rbtNo_CheckedChanged(object sender, EventArgs e)
        {

            lblMake.Visible = false;
            txtMake.Visible = false;
            lblModel.Visible = false;
            txtModel.Visible = false;
            lblPurchasePrice.Visible = false;
            txtPurchasePrice.Visible = false;
            lblTotalDeposit.Visible = false;
            txtTotalDeposit.Visible = false;
            lblInterest.Visible = false;
            txtInterest.Visible = false;
            lblInsurancePremium.Visible = false;
            txtInsurancePremium.Visible = false;
        }

        //radiobutton method to make it able for the one button to be visible when clicked and the other button to be invisible
        private void rbtRent_CheckedChanged(object sender, EventArgs e)
        {
            lblPriceRent.Text = "Rent of each month:";
            lblPriceRent.Visible = true;
            txtPriceRent.Visible = true;

            lblDeposit.Visible = false;
            txtDeposit.Visible = false;
            lblInterestRate.Visible = false;
            txtInterestRate.Visible = false;
            lblNumberOfMonths.Visible = false;
            txtNumberOfMonths.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        //radiobutton method to make it able for the one button to be visible when clicked and
        //the other button to be invisible, same as the one above
        private void rbtBuy_CheckedChanged(object sender, EventArgs e)
        {
            lblPriceRent.Text = "Price for Purchases:";
            lblPriceRent.Visible = true;
            txtPriceRent.Visible = true;

            lblDeposit.Visible = true;
            txtDeposit.Visible = true;
            lblInterestRate.Visible = true;
            txtInterestRate.Visible = true;
            lblNumberOfMonths.Visible = true;
            txtNumberOfMonths.Visible = true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Run the method that add the values in the array
            Values_added();

            //if-statement for the buy or rent option
            //Values that needs to be entered when an option is chosen
            if (rbtBuy.Checked == true)
            {
                Expense buy = new HomeLoan();
                buy.income = income;
                buy.LstExpenses = lstExpenses;
                buy.deposit = deposit;
                buy.interest = interest;
                buy.months = months;
                if (rbtYes.Checked == true)
                {
                    buy.LstExpenses = Car(buy.LstExpenses);
                    buy.LstExpensesNames.Add("Monthly car payments:");
                }
                buy.calculate(price);

                lblCalculate.Text = buy.ToString();
            }
            else if (rbtRent.Checked == true)
            {
                Expense rent = new Rent();
                rent.income = income;
                rent.LstExpenses = lstExpenses;
                rent.calculate(price);
                if (rbtYes.Checked == true)
                {
                    rent.LstExpenses = Car(rent.LstExpenses);
                    rent.LstExpensesNames.Add("Monthly car payments:");
                }
                rent.calculate(price);
                //Display the output
                lblCalculate.Text = rent.ToString();

            }
            else
            {
                //When no option are chosen the message below will show
                MessageBox.Show("Please select if you choose to be renting or buying a property.");
            }

            //Clears the list after calculation so that new expenses
            //can be saved anew instead of being added to existing expenses
            lstExpenses.Clear();
        }

        private List<double> Car(List<double> expenses)
        {
            BuyCar car = new BuyCar();
            car.LstExpenses = expenses;
            car.deposit = carDeposit;
            car.interest = carInterest;
            car.months = 60;
            car.Insurance = insurance;
            car.Make = make;
            car.Model = model;
            car.calculate(carPrice);
            expenses = car.LstExpenses;
            return expenses;
        }
    

        private void Values_added()
        {
            //try and catch statement to prevent errors
            //The error should check the input to know which error occured
            var error = checkInput();

            try
            {
                //The statement will execute if the error is true
                if (error == true)
                {
                    throw new ArgumentNullException();
                }
                //values can only be numeric values so if a string is entered the try
                //and catch statement will occur
                price = Convert.ToDouble(txtPriceRent.Text);
                income = Convert.ToDouble(txtTotalMonthlyIncome.Text);
                lstExpenses.Add(Convert.ToDouble(txtGroceries.Text));
                lstExpenses.Add(Convert.ToDouble(txtWaterAndLights.Text));
                lstExpenses.Add(Convert.ToDouble(txtTravelCosts.Text));
                lstExpenses.Add(Convert.ToDouble(txtCellphoneAndTelephone.Text));
                lstExpenses.Add(Convert.ToDouble(txtOtherExpences.Text));

                lblCalculate.Visible = true;

                if (rbtBuy.Checked == true)
                {
                    deposit = Convert.ToDouble(txtDeposit.Text);
                    interest = Convert.ToDouble(txtInterestRate.Text) / 100;
                    months = Convert.ToDouble(txtNumberOfMonths.Text);
                }

                //If statement stores car values only if yes 
                //option is selected
                if (rbtYes.Checked == true)
                {
                    make = txtMake.Text;
                    model = txtModel.Text;
                    carPrice = Convert.ToDouble(txtPurchasePrice.Text);
                    carDeposit = Convert.ToDouble(txtTotalDeposit.Text);
                    carInterest = Convert.ToDouble(txtInterest.Text) / 100;
                    insurance = Convert.ToDouble(txtInsurancePremium.Text);
                }
            }
            //Messages shown when errors are been catched
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please fill in all the fields");
            }
            catch (FormatException)
            {
                MessageBox.Show("Only numeric values can be entered");
            }

        }

        //checkInput is an method I made to know whether there an error is or not.
        private bool checkInput()
        {
            //There is no error, but if the if statement is true then there is an error.
            var error = false;
            foreach (TextBox t in Controls.OfType<TextBox>())
            {
                //if the textbox length is 0 meaning there is nothing entered in it then the statement is true and
                //if the rent or buy option values that must be placed beneath visible are
                if (t.TextLength == 0 && t.Visible == true)
                {
                    //when the statement is true the textbox will be highlighted a dark blue colour
                    error = true;
                    t.BackColor = Color.DarkBlue;
                }
                else
                {
                    //otherwise if there is something entered it will be highlighted in white
                    t.BackColor = Color.White;
                }
            }
            //value returned whether it is true or false
            return error;
        }
    }
}
