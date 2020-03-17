using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    //Opened Dashboard.ca code but right clicking on Dashboard.ca in Solution explorer and selecting "View Code"
    public partial class Dashboard : Form
    {
        ShoppingCartModel cart = new ShoppingCartModel();

        public Dashboard()
        {
            InitializeComponent();
            PopulateCartWithDemoData();
        }

        private void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }

        private void messageBoxDemoButton_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal(SubTotalAlert, CalcualteLeveledDiscount, PrintOutDiscountAlert);

            MessageBox.Show($"The total is {total:C2}");
        }


        //This is a event and it's wired up as a delegate (Observer Pattern)
        private void textBoxDemoButton_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal((subTotal) => subTotalTextBox.Text = $"{subTotal:C2}",
                (products, subTotal) => subTotal - (products.Count), /*this inline delegate returns a value. That return value comes from ShoppingCartModel.GenerateTotal method*/
                (message) => {/*runs method, but doesn't do anything*/ });

            totalTextBox.Text = $"{total:C2}";
        }

        private void PrintOutDiscountAlert(string message)
        {
            // Console.WriteLine really only works in the Console App, doesn't work in WinForm apps unless run in Debug mode. 
            MessageBox.Show(message);
        }

        private void SubTotalAlert(decimal subTotal)
        {
            MessageBox.Show($"The subtotal is {subTotal:C2}");
        }

        private decimal CalcualteLeveledDiscount(List<ProductModel> products, decimal subTotal)
        {
                return subTotal - products.Count; //BAD Business logic....but this is a demo
        }
    }
}
