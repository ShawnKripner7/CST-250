/*
 * Shawn Kripner
 * CST-250
 * 4/16/2025
 * Pizza Maker
 * Activity 4
 */

using PizzaMaker.Models;

namespace PizzaMaker
{
    public partial class FrmPizzaMaker : Form
    {
        // Class level variable declarations
        private PizzaModel _pizza;

        /// <summary>
        /// Default constructor for FrmPizzaMaker
        /// </summary>
        public FrmPizzaMaker()
        {
            InitializeComponent();

            // Initialize the current order
            _pizza = new PizzaModel();

            // Disable the Create Pizza button
            btnCreatePizza.Enabled = false;

            // Disable the Reset Form button
            btnResetForm.Enabled = false;

            // Update the price of the pizza
            UpdatePrice();

            // Update the maximums for hsbSauce and hsbCheese
            hsbSauce.Maximum = 100 + hsbSauce.LargeChange - 1;
            hsbCheese.Maximum = 100 + hsbCheese.LargeChange - 1;
        }

        /// <summary>
        /// Enables the reset and create buttons
        /// for the order pizza form
        /// </summary>
        public void EnablePizzaCreation()
        {
            // Enable the Create Pizza button
            btnCreatePizza.Enabled = true;

            // Enable the Reset Form button
            btnResetForm.Enabled = true;
        }

        /// <summary>
        /// Update the price of the pizza
        /// </summary>
        public void UpdatePrice()
        {
            // Declare and initialize
            decimal price = 15;

            // Add 50 cents for each ingredient
            price += (_pizza.Ingredients.Count * .50m);

            // Add 50 cents for each special add on
            price += (_pizza.StrangeAddOns.Count * .50m);

            // Add $1 if the crust if gluten free
            if (_pizza.Crust == "Gluten Free")
            {
                price += 1;
            }

            // Update the price of the pizza
            _pizza.Price = price;

            // Update lblPizzaPrice
            lblPizzaPrice.Text = $"{price:C2}";
        }

        /// <summary>
        /// Leave event handler for txtName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNameLeaveEH(object sender, EventArgs e)
        {
            // Set the pizzas client name to the text of txtName
            _pizza.ClientName = txtName.Text;

            // Call the Enable Pizza Creation Method
            EnablePizzaCreation();
        }

        /// <summary>
        /// Checked changed event handler for ingredient check boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChbIngredientCheckedChangedEH(object sender, EventArgs e)
        {
            // Get the check box from the sender parameter
            CheckBox checkbox = sender as CheckBox;

            // Make sure the checkbox is not null
            if (checkbox != null)
            {
                // If the checkbox is checked, add the ingredient to the pizza
                if (checkbox.Checked)
                {
                    // Add the current ingredient to the pizza
                    _pizza.Ingredients.Add(checkbox.Text);
                }
                // If the checkbox is not checked, remove the ingredient
                else
                {
                    // Remove the current ingredient from the pizza
                    _pizza.Ingredients.Remove(checkbox.Text);
                }
            }

            // Update the price of the pizza
            UpdatePrice();
        }

        /// <summary>
        /// Selected Index Changed event handler for lsbStrangeAddOns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbStrangeAddOnsSelectedIndexChangedEH(object sender, EventArgs e)
        {
            // Get the list of selected items and set the StrangeAddOns property of the pizza
            _pizza.StrangeAddOns = lsbStrangeAddOns.SelectedItems.Cast<string>().ToList();

            // Update the price of the pizza
            UpdatePrice();
        }

        /// <summary>
        /// Checked changed event handler for crust radio buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoCrustCheckedChangedEH(object sender, EventArgs e)
        {
            // Get the radio button from the sender object
            RadioButton radioButton = sender as RadioButton;

            // Make sure the radio button is not null
            if (radioButton != null && radioButton.Checked)
            {
                // Set the current crust to the pizzas crust
                _pizza.Crust = radioButton.Text;
            }

            // Update the price of the pizza
            UpdatePrice();
        }

        /// <summary>
        /// Value changed event handler for the horizontal scroll bars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HsbExtraGoodiesValueChangedEH(object sender, EventArgs e)
        {
            // Cast the sender object to an HScrollBar
            HScrollBar scrollBar = sender as HScrollBar;

            // Make sure the scroll bar is not null
            if (scrollBar != null)
            {
                // Check if the scroll bar is hsbSauce
                if (scrollBar == hsbSauce)
                {
                    // Updated the SauceQty using the scroll bars value
                    _pizza.SauceQty = scrollBar.Value;

                    // Update lblSauce label
                    lblSauce.Text = scrollBar.Value.ToString();
                }
                // Check if the scroll bar is hsbCheese
                else if (scrollBar == hsbCheese)
                {
                    // Updated the CheeseQty using the scroll bars value
                    _pizza.CheeseQty = scrollBar.Value;

                    // Update lblCheese label
                    lblCheese.Text = scrollBar.Value.ToString();
                }
            }
        }

        /// <summary>
        /// Value changed event handler for dtpDeliveryTime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtpDeliveryTimeValueChangedEH(object sender, EventArgs e)
        {
            // Update the delivery time for the pizza
            _pizza.DeliveryTime = dtpDeliveryTime.Value;
        }
    }
}