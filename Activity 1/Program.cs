/*
 * Shawn Kripner
 * CST - 250
 * 03/24/2026
 * Vehicle Class Library
 * Activity 1
 */

//------------------------------------------------------------
// Start of the Main Method
//------------------------------------------------------------

// Print a welcome message to the user
using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.BusinessLogicLayer;

Console.WriteLine("Welcome to the Vehicle Shop! To begin, please create a selection of vehicles and add them to the inventory. " +
    "Once the inventory is populated, you can proceed by adding vehicles to your cart. " +
    "Finally, when you're ready to complete your purchase, proceed to the checkout where your total bill will be calculated.");

// Call the control loop method to mangae the program running
ControlLoop();

//------------------------------------------------------------
// End of the Main Method
//------------------------------------------------------------

// Read an integer input from user
// Read an integer input from user
static int ReadChoice()
{
    // Declare and initialize
    // Set input as a nullable reference type
    string? input = "";
    int choice = -1;

    // Loop until the user enters a valid choice
    while (choice == -1)
    {
        // Print the users options
        Console.Write("Choose an action: \n0) Quit \n1) Print the inventory \n2) Print the shopping cart \n3) " +
            "Create a vehicle \n4) Add a vehicle to the shopping cart \n5) " +
            "Checkout \n6) Save inventory to a text file \n7) Load inventory from a text file \nInput: ");

        // Read the user input from the console
        input = Console.ReadLine();

        // Make sure the user entered a value
        if (!string.IsNullOrEmpty(input))
        {
            try
            {
                // Parse the input from the user to the choice variable
                choice = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please enter a valid number. The number entered was either too small or too large.");
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was an exception " + exp + ". Please try again.");
            }
        }
    }

    // Return the users input
    return choice;
}

// Control the car store loop
static void ControlLoop()
{
    // Create an instance of the store logic class
    StoreLogic storeLogic = new StoreLogic();
    // Declare and initialize other variables
    int choice = -1, id = 0, year = 0, numWheels = 0;
    string make = "", model = "";
    decimal price = 0m, total = 0m;
    // Specialty vehicle variables
    bool isConvertible = false, hasSideCar = false, hasBedCover = false;
    decimal trunkSize = 0m, seatHeight = 0m, bedSize = 0m;
    List<VehicleModel> vehicleList = new List<VehicleModel>();
    VehicleModel vehicle = new VehicleModel();
    string color = "";
    int miles = 0;

    // Continue the loop until the user enters 0
    while (choice != 0)
    {
        // Get the input from the user
        choice = ReadChoice();

        // Use the users choice to switch between the options
        switch (choice)
        {
            // Quit
            case 0:
                Console.WriteLine("Have a great day");
                break;

            // Print the inventory
            case 1:
                // Get the inventory list from storeLogic
                vehicleList = storeLogic.GetInventory();
                // Print a title for the list
                Console.WriteLine("Inventory: ");
                // Loop through the inventory list
                foreach (VehicleModel inventoryVehicle in vehicleList)
                {
                    // Print each vehicle from the inventory
                    Console.WriteLine(inventoryVehicle);
                }
                Console.WriteLine();
                break;

            // Print the shopping cart
            case 2:
                // Get the shopping cart list from storeLogic
                vehicleList = storeLogic.GetShoppingCart();
                // Print a title for the list
                Console.WriteLine("Shopping Cart: ");
                // Loop through the shopping cart list
                foreach (VehicleModel shoppingCartVehicle in vehicleList)
                {
                    // Print each vehicle from the shopping cart 
                    Console.WriteLine(shoppingCartVehicle);
                }
                Console.WriteLine();
                break;

            // Create a vehicle
            case 3:
                // Read the type of vehicle
                // Using safe input to prevent crashes from invalid user input
                choice = ReadInt("Enter 1 to create a car, 2 to create a motorcycle, 3 to create a pickup, or 4 to create a vehicle: ");

                // Get the common properties for the vehicle
                // Read in the make of the vehicle
                Console.Write("Enter the make of the vehicle: ");
                make = Console.ReadLine();
                // Read the model of the vehicle
                Console.Write("Enter the model of the vehicle: ");
                model = Console.ReadLine();

                // Read the year of the vehicle (safe input instead of int.Parse)
                year = ReadInt("Enter the year of the vehicle: ");

                // Read the price of the vehicle (safe input instead of decimal.Parse)
                price = ReadDecimal("Enter the price of the vehicle: ");

                // Read the number of wheels on the vehicle (safe input)
                numWheels = ReadInt("Enter the number of wheels on the vehicle: ");

                // Additional custom properties added for the challenge
                Console.Write("Enter the color of the vehicle: ");
                color = Console.ReadLine();

                // Safe input for miles to prevent crashes
                miles = ReadInt("Enter the miles on the vehicle: ");

                // Switch statement to read the vehicle-specific properties
                switch (choice)
                {
                    // Car
                    case 1:
                        // Read the convertible status for the car (safe boolean input)
                        isConvertible = ReadBool("Enter if the car is a convertible (true/false): ");
                        // Read the trunk size for the car (safe decimal input)
                        trunkSize = ReadDecimal("Enter the trunk size of the car in cubic feet: ");
                        // Create a new car
                        vehicle = new CarModel(id, make, model, year, price, numWheels, color, miles, isConvertible, trunkSize);
                        break;

                    // Motorcycle
                    case 2:
                        // Read the side car status for the motorcycle (safe boolean input)
                        hasSideCar = ReadBool("Enter if the motorcycle has a side car (true/false): ");
                        // Read the seat height for the motorcycle (safe decimal input)
                        seatHeight = ReadDecimal("Enter the seat height of the motorcycle in inches: ");
                        // Create a new motorcycle
                        vehicle = new MotorcycleModel(id, make, model, year, price, numWheels, color, miles, hasSideCar, seatHeight);
                        break;

                    // Pickup
                    case 3:
                        // Read the bed cover status for the pickup (safe boolean input)
                        hasBedCover = ReadBool("Enter if the pickup has a bed cover (true/false): ");
                        // Read the bed size for the pickup (safe decimal input)
                        bedSize = ReadDecimal("Enter the bed size of the pickup in cubic feet: ");
                        // Create a new pickup
                        vehicle = new PickupModel(id, make, model, year, price, numWheels, color, miles, hasBedCover, bedSize);
                        break;

                    // Vehicle
                    default:
                        // Create a new vehicle
                        vehicle = new VehicleModel(id, make, model, year, price, numWheels, color, miles);
                        break;
                }

                // Add the vehicle to the inventory
                storeLogic.AddVehicleToInventory(vehicle);
                Console.WriteLine();
                break;

            // Add a vehicle to the shopping cart
            case 4:
                // Get the id of the vehicle from the user
                Console.Write("Enter the id of the vehicle you want to buy: ");
                id = int.Parse(Console.ReadLine());
                // Add the vehicle to the shopping cart
                storeLogic.AddVehicleToCart(id);
                Console.WriteLine();
                break;

            // Checkout
            case 5:
                // Checkout the user
                total = storeLogic.Checkout();
                // Print the total from the checkout method
                Console.WriteLine("Your total is: $" + total);
                Console.WriteLine();
                break;

            // Save inventory to a text file
            case 6:
                // Use the business logic layer to write the inventory to the file
                storeLogic.WriteInventory();
                // Print out a success message
                Console.WriteLine("The inventory has been saved to the text file");
                Console.WriteLine();
                break;

            // Load inventory from a text file
            case 7:
                // Use the business logic layer to read the inventory from the file
                storeLogic.ReadInventory();
                // Print out a success message
                Console.WriteLine("The inventory has been read from the text file");
                Console.WriteLine();
                break;

            // Other input
            default:
                Console.WriteLine("Invalid Choice");
                Console.WriteLine();
                break;
        }
    }
} // End of ControlLoop method

//------------------------------------------------------------
// Read a decimal value from the user safely
//------------------------------------------------------------
static decimal ReadDecimal(string prompt)
{
    decimal value = 0m;
    bool isValid = false;

    while (!isValid)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        try
        {
            value = decimal.Parse(input);
            isValid = true;
        }
        catch (Exception)
        {
            Console.WriteLine("Please enter a valid decimal number.");
        }
    }

    return value;
}
//------------------------------------------------------------
// End of ReadDecimal method
//------------------------------------------------------------


//------------------------------------------------------------
// Read a boolean value from the user safely
//------------------------------------------------------------
static bool ReadBool(string prompt)
{
    bool value = false;
    bool isValid = false;

    while (!isValid)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        try
        {
            value = bool.Parse(input);
            isValid = true;
        }
        catch (Exception)
        {
            Console.WriteLine("Please enter true or false.");
        }
    }

    return value;
}
//------------------------------------------------------------
// End of ReadBool method
//------------------------------------------------------------
//------------------------------------------------------------
// Read an integer value from the user safely
//------------------------------------------------------------
static int ReadInt(string prompt)
{
    int value = 0;
    bool isValid = false;

    while (!isValid)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        try
        {
            value = int.Parse(input);
            isValid = true;
        }
        catch (Exception)
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }

    return value;
}
//------------------------------------------------------------
// End of ReadInt method
//------------------------------------------------------------

