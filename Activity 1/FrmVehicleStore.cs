/*
 * Shawn Kripner
 * CST-250
 * 3/27/2025
 * Vehicle Class Inventory
 * Activity 1
 */

using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.BusinessLogicLayer;

namespace VehicleStoreGUIApp
{
    public partial class FrmVehicleStore : Form
    {

        // Clas level variables
        string currentVehicleType;
        bool isVehicleTypeValid = false, isMakeValid = false, isModelValid = false,
        isYearValid = false, isPriceValid = false, isWheelsValid = false,
        isSpecialtyBooleanValid = false, isSpecialtyDecimalValid = false;

        // Create a new vehicle store logic variable
        private StoreLogic _storeLogic;

        private BindingSource _inventoryBindingSource;
        private BindingSource _shoppingCartBindingSource;

        /// <summary>
        /// Default constructor for FrmVehicleStore
        /// </summary>
        public FrmVehicleStore()
        {
            InitializeComponent();
            // Initialize the current vehicle to create
            currentVehicleType = "";
            // Hide the error labels
            lblVehicleTypeError.Visible = false;
            lblMakeError.Visible = false;
            lblModelError.Visible = false;
            lblYearError.Visible = false;
            lblPriceError.Visible = false;
            lblWheelsError.Visible = false;
            lblSpecialtyBooleanError.Visible = false;
            lblSpecialtyDecimalError.Visible = false;
            // Initialize the store logic variable
            _storeLogic = new StoreLogic();
            _storeLogic = new StoreLogic();

            _inventoryBindingSource = new BindingSource();
            _shoppingCartBindingSource = new BindingSource();

            _inventoryBindingSource.DataSource = _storeLogic.GetInventory();
            _shoppingCartBindingSource.DataSource = _storeLogic.GetShoppingCart();

            lstInventory.DataSource = _inventoryBindingSource;
            lstShoppingCart.DataSource = _shoppingCartBindingSource;
        }

        /// <summary>
        /// Validate that the user has selected a vehicle type
        /// </summary>
        private void ValidateVehicleType()
        {
            if (rdoCar.Checked || rdoMotorcycle.Checked || rdoPickup.Checked || rdoVehicle.Checked)
            {
                // Hide the error label
                lblVehicleTypeError.Visible = false;
                // Set the flag
                isVehicleTypeValid = true;
            }
            else
            {
                // Show the error label
                lblVehicleTypeError.Visible = true;
                // Set the flag
                isVehicleTypeValid = false;
            }
        }

        /// <summary>
        /// Validate the make textbox
        /// </summary>
        private string ValidateTxtMake()
        {
            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtMake.Text))
            {
                lblMakeError.Visible = true;
                // Set the flag
                isMakeValid = false;
            }
            else
            {
                lblMakeError.Visible = false;
                // Clear the flag
                isMakeValid = true;
            }
            // Return the text from the textbox
            return txtMake.Text;
        }

        /// <summary>
        /// Validate the model textbox
        /// </summary>
        private string ValidateTxtModel()
        {
            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtModel.Text))
            {
                lblModelError.Visible = true;
                // Set the flag
                isModelValid = false;
            }
            else
            {
                lblModelError.Visible = false;
                // Clear the flag
                isModelValid = true;
            }
            // Return the text from the textbox
            return txtModel.Text;
        }

        /// <summary>
        /// Validate the year textbox
        /// </summary>
        private int ValidateTxtYear()
        {
            // Declare and initialize
            int yearValue = -1;

            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                lblYearError.Visible = true;
                // Set the flag
                isYearValid = false;
            }
            else
            {
                lblYearError.Visible = false;
                // Attempt to parse the textbox value
                isYearValid = int.TryParse(txtYear.Text, out yearValue);
                // If the parse failed, show the error message
                if (!isYearValid)
                {
                    lblYearError.Visible = true;
                }
            }
            // Return the year
            return yearValue;
        }

        /// <summary>
        /// Validate the price textbox
        /// </summary>
        private decimal ValidateTxtPrice()
        {
            // Declare and initialize
            decimal priceValue = -1;

            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                lblPriceError.Visible = true;
                // Set the flag
                isPriceValid = false;
            }
            else
            {
                lblPriceError.Visible = false;
                // Attempt to parse the textbox value
                isPriceValid = decimal.TryParse(txtPrice.Text, out priceValue);
                // If the parse failed, show the error message
                if (!isPriceValid)
                {
                    lblPriceError.Visible = true;
                }
            }
            // Return the price
            return priceValue;
        }

        /// <summary>
        /// Validate the wheels textbox
        /// </summary>
        private int ValidateTxtWheels()
        {
            // Declare and initialize
            int wheelsValue = -1;

            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtWheels.Text))
            {
                lblWheelsError.Visible = true;
                // Set the flag
                isWheelsValid = false;
            }
            else
            {
                lblWheelsError.Visible = false;
                // Attempt to parse the textbox value
                isWheelsValid = int.TryParse(txtWheels.Text, out wheelsValue);
                // If the parse failed, show the error message
                if (!isWheelsValid)
                {
                    lblWheelsError.Visible = true;
                }
            }
            // Return the year
            return wheelsValue;
        }

        /// <summary>
        /// Validate that the user has selected a specialty boolean
        /// </summary>
        private bool ValidateSpecialtyBoolean()
        {
            if (currentVehicleType != "Vehicle")
            {
                if (rdoSpecialtyYes.Checked || rdoSpecialtyNo.Checked)
                {
                    // Hide the error label
                    lblSpecialtyBooleanError.Visible = false;
                    // Set the flag
                    isSpecialtyBooleanValid = true;
                }
                else
                {
                    // Show the error label
                    lblSpecialtyBooleanError.Visible = true;
                    // Set the flag
                    isSpecialtyBooleanValid = false;
                }
            }
            else
            {
                // Hide the error label
                lblSpecialtyBooleanError.Visible = false;
                // Set the flag
                isSpecialtyBooleanValid = true;
            }
            return rdoSpecialtyYes.Checked;
        }

        /// <summary>
        /// Validate the specialty decimal textbox
        /// </summary>
        private decimal ValidateSpecialtyDecimal()
        {
            // Declare and initialize
            decimal specialtyDecimalValue = -1;

            if (currentVehicleType != "Vehicle")
            {
                // Test for a null/empty textbox
                if (string.IsNullOrEmpty(txtSpecialtyDecimal.Text))
                {
                    lblSpecialtyDecimalError.Visible = true;
                    // Set the flag
                    isSpecialtyDecimalValid = false;
                }
                else
                {
                    lblSpecialtyDecimalError.Visible = false;
                    // Attempt to parse the textbox value
                    isSpecialtyDecimalValid = decimal.TryParse(txtSpecialtyDecimal.Text, out specialtyDecimalValue);
                    // If the parse failed, show the error message
                    if (!isSpecialtyDecimalValid)
                    {
                        lblSpecialtyDecimalError.Visible = true;
                    }
                }
            }
            else
            {
                lblSpecialtyDecimalError.Visible = false;
                // Set the flag
                isSpecialtyDecimalValid = true;
            }
            // Return the specialty decimal
            return specialtyDecimalValue;
        }

        /// <summary>
        /// Click event handler to create a car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoCarClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Car";

            // Change the label for the specialty boolean
            lblSpecialtyBoolean.Text = "Is the car a convertible?";
            // Change the label for the specialty decimal
            lblSpecialtyDecimal.Text = "Trunk Size (cubit feet):";

            // Show the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = true;
            rdoSpecialtyYes.Visible = true;
            rdoSpecialtyNo.Visible = true;

            // Show the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = true;
            txtSpecialtyDecimal.Visible = true;


        }

        /// <summary>
        /// Click event handler to create a motorcycle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoMotorcycleClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Motorcycle";

            // Change the label for the specialty boolean
            lblSpecialtyBoolean.Text = "Does the motorcycle have a side car?";
            // Change the label for the specialty decimal
            lblSpecialtyDecimal.Text = "Seat Height (inches):";

            // Show the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = true;
            rdoSpecialtyYes.Visible = true;
            rdoSpecialtyNo.Visible = true;

            // Show the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = true;
            txtSpecialtyDecimal.Visible = true;
        }

        /// <summary>
        /// Click event handler to add a general vehicle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoVehicleClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Vehicle";

            // Hide the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = false;
            rdoSpecialtyYes.Visible = false;
            rdoSpecialtyNo.Visible = false;
            // Hide the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = false;
            txtSpecialtyDecimal.Visible = false;
        }

        /// <summary>
        /// Click event handler to add a general vehicle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoPickupClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Vehicle";

            // Hide the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = false;
            rdoSpecialtyYes.Visible = false;
            rdoSpecialtyNo.Visible = false;
            // Hide the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = false;
            txtSpecialtyDecimal.Visible = false;
        }

        /// <summary>
        /// Click Event handler to create a new vehicle
        /// and add it to the inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateClickEH(object sender, EventArgs e)
        {
            // Declare and initialize variables
            int id = 0;
            string make = "", model = "", color = "";
            int year = -1, wheels = -1, miles = -1;
            decimal price = -1m, specialtyDecimal = -1m;
            bool specialtyBoolean = false;
            VehicleModel vehicle;


            // Test for null/empty textboxes
            ValidateVehicleType();
            make = ValidateTxtMake();
            model = ValidateTxtModel();
            year = ValidateTxtYear();
            price = ValidateTxtPrice();
            wheels = ValidateTxtWheels();
            specialtyBoolean = ValidateSpecialtyBoolean();
            specialtyDecimal = ValidateSpecialtyDecimal();

            // Check the state of the flags
            if (isVehicleTypeValid && isMakeValid && isModelValid && isYearValid && isPriceValid &&
                isWheelsValid && isSpecialtyBooleanValid && isSpecialtyDecimalValid)
            {
                switch (currentVehicleType)
                {
                    case "Car":
                        // Create a new car
                        vehicle = new CarModel(id, make, model, year, price, wheels, color, miles,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    case "Motorcycle":
                        // Create a new motorcycle
                        vehicle = new MotorcycleModel(id, make, model, year, price, wheels, color, miles,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    case "Pickup":
                        // Create a new pickup
                        vehicle = new PickupModel(id, make, model, year, price, wheels, color, miles,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    default:
                        // Create a new vehicle
                        vehicle = new VehicleModel(id, make, model, year, price, wheels, color, miles);
                        break;
                }

                // Add the vehicle to the inventory
                _storeLogic.AddVehicleToInventory(vehicle);

                // Show the user a success message
                MessageBox.Show($"The following car has been added to the inventory:\n{vehicle}");

                // Clear the input fields
                rdoCar.Checked = false;
                rdoMotorcycle.Checked = false;
                rdoPickup.Checked = false;
                rdoVehicle.Checked = false;
                txtMake.Clear();
                txtModel.Clear();
                txtYear.Clear();
                txtPrice.Clear();
                txtWheels.Clear();
                rdoSpecialtyYes.Checked = false;
                rdoSpecialtyNo.Checked = false;
                txtSpecialtyDecimal.Clear();

                // Refresh the list control
                _inventoryBindingSource.ResetBindings(false);
            }
        }
    }
 }

