/*
 * Shawn Kripner
 * CST - 250
 * 04/09/2026
 * Factorial Recursion
 * Activity 3
 */

//------------------------------------------------------------
// Start of the Main Method
//------------------------------------------------------------

// Declare and initialize
using FactorialRecursion.Services.BusinessLogicLayer;
using System.Numerics;

FactorialLogic factorialLogic = new FactorialLogic();
int input = 0;
BigInteger iterativeAns = 0, recursiveAns = 0;

// Prompt the user
Console.Write("Enter a positive number: ");

// Get the users input
input = Utility.ReadIntFromConsole();

// Solve the factorial using iteration
Console.WriteLine("Solving the factorial using iteration...");
iterativeAns = factorialLogic.SolveIterativeFactorial(input);
Console.WriteLine($"Answer: {iterativeAns}");

// Solve the factorial using recursion
Console.WriteLine("Solving the factorial using recursion...");
recursiveAns = factorialLogic.SolveRecursiveFactorial(input);
Console.WriteLine($"Answer: {recursiveAns}");

//------------------------------------------------------------
// End of the Main Method
//------------------------------------------------------------

static class Utility
{
    /// <summary>
    /// Read integer input from the console
    /// </summary>
    /// <returns></returns>
    internal static int ReadIntFromConsole()
    {
        // Declare and initialize
        string input = "";
        int number = -1;

        // Get the current input
        input = Console.ReadLine();

        // Check if the input is valid
        while (!int.TryParse(input, out number))
        {
            // Show the user an error message and prompt them again
            Console.WriteLine("Invalid input. Please try again:");

            // Get the new input
            input = Console.ReadLine();
        }

        // Return the resulting integer from the user
        return number;
    }
}