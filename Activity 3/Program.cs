/*
 * Shawn Kripner
 * CST - 250
 * 04/09/2026
 * Count To One Recursion
 * Activity 3
 */

class Program
{
    static void Main(string[] args)
    {
        //------------------------------------------------------------
        // Start of the Main Method
        //------------------------------------------------------------

        // Declare and initialize
        int choice = 0, result = 0;
        string input = "";

        // Prompt the user for a number
        Console.Write("Enter a positive number: ");

        // Get the users input
        input = Console.ReadLine();

        // See if the user entered valid input
        while (!int.TryParse(input, out choice) || choice <= 0)
        {
            Console.WriteLine("Invalid number");

            // Re-Prompt the user for a number
            Console.Write("Enter a positive number: ");

            // Get the users input
            input = Console.ReadLine();
        }

        // Call the CountToOne function
        result = Utility.CountToOne(choice);
        Console.WriteLine($"The end number is {result}");

        //------------------------------------------------------------
        // End of the Main Method
        //------------------------------------------------------------
    }
}

//------------------------------------------------------------
// Start of the Utility class
//------------------------------------------------------------

// 0 references
static class Utility
{
    /// <summary>
    /// Count to one using recursion
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    // 2 references
    internal static int CountToOne(int num)
    {
        // Print out the current number
        Console.WriteLine($"The current number is {num}");

        // Check if the number is 1
        if (num == 1)
        {
            return 1;
        }
        else
        {
            // Check if the number is even
            if ((num % 2) == 0)
            {
                Console.WriteLine("The number is even. Divide by 2");

                // Divide the number by 2 and call the function
                return CountToOne(num / 2);
            }
            else
            {
                Console.WriteLine("The number is odd. Add 1");

                // Add 1 and call the function
                return CountToOne(num + 1);
            }
        }
    }
}