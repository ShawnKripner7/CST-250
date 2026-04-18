/*
 * Shawn Kripner
 * CST-250
 * 4/16/2025
 * Pizza Maker
 * Activity 4
 */

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PizzaMakerClassLibrary.Models;
using PizzaMakerClassLibrary.Services.BusinessLogicLayer;

namespace PizzaMaker
{
    public partial class FrmPizzaMaker : Form
    {
        // Class level variable declarations
        private PizzaModel _pizza;
        private PizzaLogic _pizzaLogic;

        /// <summary>
        /// Default constructor for FrmPizzaMaker
        /// </summary>
        public FrmPizzaMaker()
        {
            InitializeComponent();

            // Initialize the current order
            _pizza = new PizzaModel();

            // Initialize the business logic layer
            _pizzaLogic = new PizzaLogic();

            // Disable the Create Pizza button
            btnCreatePizza.Enabled = false;

            // Disable the Reset Form button
            btnResetForm.Enabled = false;

            // Disable the See Full Order button
            btnSeeFullOrder.Enabled = false;

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
            CheckBox? checkbox = sender as CheckBox;

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
            RadioButton? radioButton = sender as RadioButton;

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
            HScrollBar? scrollBar = sender as HScrollBar;

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

        /// <summary>
        /// Click event handler for picPizzaBoxColor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicPizzaBoxColorClickEH(object sender, EventArgs e)
        {
            // Create a new color dialog object
            ColorDialog pizzaBoxColorPicker = new ColorDialog();

            // Call the ShowDialog method
            DialogResult result = pizzaBoxColorPicker.ShowDialog();

            // Check if the color picker returned OK
            if (result == DialogResult.OK)
            {
                // Set the pizza pizza box color
                _pizza.PizzaBoxColor = pizzaBoxColorPicker.Color;

                // Set the color of the picture box
                picPizzaBoxColor.BackColor = pizzaBoxColorPicker.Color;
            }
        }

        /// <summary>
        /// Click event handler for btnCreatePizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreatePizzaClickEH(object sender, EventArgs e)
        {
            // Declare and initialize
            bool isValidPizza = false;
            int pizzasInOrder = -1;

            // Use the pizzaLogic to call AddPizzaToOrder
            (isValidPizza, pizzasInOrder) = _pizzaLogic.AddPizzaToOrder(_pizza);

            // Check if the pizza was valid
            if (isValidPizza)
            {
                // Enable the See Full Order button
                btnSeeFullOrder.Enabled = true;

                // Reset the form
                ResetForm();
            }
            else
            {
                // Show a failure message to the user
                MessageBox.Show("Your pizza order is not complete.");
            }
        }

        /// <summary>
        /// Click event handler for btnResetForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetFormClickEH(object sender, EventArgs e)
        {
            // Reset the form
            ResetForm();
        }

        /// <summary>
        /// Reset the pizza maker form
        /// </summary>
        private void ResetForm()
        {
            // Set the pizza to a new instance
            _pizza = new PizzaModel();

            // Reset the controls of the form
            ResetControls(this);

            // Update the price of the pizza
            UpdatePrice();
        }

        /// <summary>
        /// Reset the controls within the parent control
        /// </summary>
        /// <param name="parentControl"></param>
        private void ResetControls(Control parentControl)
        {
            // Loop through the controls within the parent control
            foreach (Control control in parentControl.Controls)
            {
                // Get the type of the control
                Type controlType = control.GetType();

                // Save the type of the control as a string
                string type = controlType.Name.ToString();

                // Use a switch case to handle the resets
                switch (type)
                {
                    case "TextBox":
                        // Cast the control to a textbox
                        TextBox textbox = (TextBox)control;

                        // Clear the textbox
                        textbox.Clear();
                        break;

                    case "CheckBox":
                        // Cast the control to a checkbox
                        CheckBox checkbox = (CheckBox)control;

                        // Make sure the checkbox is not checked
                        checkbox.Checked = false;
                        break;

                    case "ListBox":
                        // Cast the control to a list box
                        ListBox listbox = (ListBox)control;

                        // Clear the selected items in the list box
                        listbox.ClearSelected();
                        break;

                    case "RadioButton":
                        // Cast the control to a radio button
                        RadioButton radioButton = (RadioButton)control;

                        // Make sure the radio button is not checked
                        radioButton.Checked = false;
                        break;

                    case "HScrollBar":
                        // Cast the control to a horizontal scroll bar
                        HScrollBar hScrollBar = (HScrollBar)control;

                        // Set the scroll bars value to 0
                        hScrollBar.Value = 0;
                        break;

                    case "DateTimePicker":
                        // Cast the control to a date time picker
                        DateTimePicker dateTimePicker = (DateTimePicker)control;

                        // Set the date to 1/1/2025 12:00am
                        dateTimePicker.Value = new DateTime(2025, 1, 1, 0, 0, 0);
                        break;

                    case "PictureBox":
                        // Cast the control to a picture box
                        PictureBox pictureBox = (PictureBox)control;

                        // Change the picture box back color to the default
                        pictureBox.BackColor = SystemColors.Control;
                        break;
                }

                // Check if the control has controls (children)
                if (control.HasChildren)
                {
                    // Recursively call the Reset method using the current control
                    ResetControls(control);
                }
            }
        } // End of ResetControls method

        /// <summary>
        /// Click event handler for btnSeeFullOrder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSeeFullOrderClickEH(object sender, EventArgs e)
        {
            // Declare and initialize
            List<PizzaModel> pizzaList;

            // Get the pizza list from pizzaLogic
            pizzaList = _pizzaLogic.GetPizzaOrder();

            // Create a new form with the pizza list
            FrmOrderDetails frmOrderDetails = new FrmOrderDetails(pizzaList, _pizzaLogic);

            // Update the label with the pizza order
            frmOrderDetails.DisplayPizzas();

            // Show the form
            frmOrderDetails.ShowDialog();
        }
    }
}