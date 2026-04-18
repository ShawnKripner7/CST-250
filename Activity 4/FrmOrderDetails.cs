/*
 * Shawn Kripner
 * CST-250
 * 4/16/2025
 * Pizza Maker
 * Activity 4
 */

using System.Collections.Generic;
using System.Windows.Forms;
using PizzaMakerClassLibrary.Models;
using PizzaMakerClassLibrary.Services.BusinessLogicLayer;

namespace PizzaMaker
{
    public partial class FrmOrderDetails : Form
    {
        // Declare class level variables
        private List<PizzaModel> _pizzaOrder;
        private PizzaLogic _pizzaLogic;

        public FrmOrderDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized constructor for FrmOrderDetails
        /// </summary>
        /// <param name="pizzaOrder"></param>
        public FrmOrderDetails(List<PizzaModel> pizzaOrderList, PizzaLogic pizzaBusinessLogic)
        {
            // Initialize the form
            InitializeComponent();

            // Initialize the class level variables
            _pizzaOrder = pizzaOrderList;
            _pizzaLogic = pizzaBusinessLogic;
        }

        /// <summary>
        /// Display the pizzas on the form
        /// </summary>
        public void DisplayPizzas()
        {
            // Clear the label
            lblOrderDetails.Text = "";

            // Loop through the pizza order list
            foreach (PizzaModel pizza in _pizzaOrder)
            {
                lblOrderDetails.Text +=
                    $"Name: {pizza.ClientName}\n" +
                    $"Ingredients: {string.Join(", ", pizza.Ingredients)}\n" +
                    $"Strange Add Ons: {string.Join(", ", pizza.StrangeAddOns)}\n" +
                    $"Crust: {pizza.Crust}\n" +
                    $"Sauce: {pizza.SauceQty}\n" +
                    $"Cheese: {pizza.CheeseQty}\n" +
                    $"Delivery Time: {pizza.DeliveryTime}\n" +
                    $"Pizza Box Color: {pizza.PizzaBoxColor}\n" +
                    $"Price: {pizza.Price}\n\n";
            }
        }

        /// <summary>
        /// Click event handler for btnSaveOrder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveOrderClickEH(object sender, EventArgs e)
        {
            // Declare and initialize
            bool isSaveSuccess = false;

            // Write the order to the file
            isSaveSuccess = _pizzaLogic.WriteOrderToFile();

            // Check if the save was successful
            if (isSaveSuccess)
            {
                // Show a success message to the user
                MessageBox.Show("The pizza order was saved.");
            }
            else
            {
                // Show a failure message to the user
                MessageBox.Show("An error occurred while trying to save your order. Please try again later.");
            }
        }

        /// <summary>
        /// Click event handler for btnBack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackClickEH(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }

    }
}
