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
        while (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Invalid number");

            // Re-Prompt the user for a number
            Console.Write("Enter a positive number: ");

            // Get the users input
            input = Console.ReadLine();
        }

        // reset the counter before starting
        Utility.StepCounter = 0;

        // reset the multiply rule before starting
        Utility.MultiplyUsed = false;

        // Call the CountToOne function
        result = Utility.CountToOne(choice);
        Console.WriteLine($"The end number is {result}");

        // show how many steps it took
        Console.WriteLine($"Total steps: {Utility.StepCounter}"); 

        //------------------------------------------------------------
        // End of the Main Method
        //------------------------------------------------------------
    }
}

//------------------------------------------------------------
// Start of the Utility class
//------------------------------------------------------------


static class Utility
{
    // keeps track of how many times the function runs
    public static int StepCounter = 0;

    // makes sure the multiply rule only happens one time
    public static bool MultiplyUsed = false;

    /// <summary>
    /// Count to one using recursion
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    internal static int CountToOne(int num)
    {
        // increase the counter each time the method runs
        StepCounter++;

        // Print out the current number
        Console.WriteLine($"The current number is {num}");

        // Check if the number is 1
        if (num == 1)
        {
            return 1;
        }
        else
        {
            // handle 0 so it can move to 1
            if (num == 0)
            {
                Console.WriteLine("The number is 0. Add 1");
                return CountToOne(num + 1);
            }

            // handle negative numbers by moving up
            if (num < 0)
            {
                Console.WriteLine("The number is negative. Add 1");
                return CountToOne(num + 1);
            }

            // use multiplication one time for numbers divisible by 5
            if (num % 5 == 0 && MultiplyUsed == false)
            {
                MultiplyUsed = true;
                Console.WriteLine("The number is divisible by 5. Multiply by 2");
                return CountToOne(num * 2);
            }

            // divide by 4 first if possible
            if ((num % 4) == 0)
            {
                Console.WriteLine("The number is divisible by 4. Divide by 4");
                return CountToOne(num / 4);
            }

            // then divide by 3 if possible
            if ((num % 3) == 0)
            {
                Console.WriteLine("The number is divisible by 3. Divide by 3");
                return CountToOne(num / 3);
            }

            // Check if the number is even
            if ((num % 2) == 0)
            {
                Console.WriteLine("The number is even. Divide by 2");

                // Divide the number by 2 and call the function
                return CountToOne(num / 2);
            }
            else
            {
                Console.WriteLine("The number is odd. Subtract 1");

                // Subtract 1 and call the function
                return CountToOne(num - 1);
            }
        }
    }
}