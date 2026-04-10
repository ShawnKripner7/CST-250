/*
 * Shawn Kripner
 * CST - 250
 * 04/09/2026
 * Greatest Common Divisor Recursion
 * Activity 3
 */

//------------------------------------------------------------
// Start of the Main Method
//------------------------------------------------------------

// Declare and initialize
using System.Diagnostics;
using System.Diagnostics;
using System.Collections.Generic;

int number1 = 0, number2 = 0, number3 = 0;
int recursiveResult = 0, iterativeResult = 0, multipleResult = 0;
long recursiveTime = 0, iterativeTime = 0;

// get the first number
Console.Write("Enter the first number: ");
number1 = Utility.ReadIntFromConsole();

// get the second number
Console.Write("Enter the second number: ");
number2 = Utility.ReadIntFromConsole();

// get the third number
Console.Write("Enter the third number: ");
number3 = Utility.ReadIntFromConsole();

// time the recursive gcd
Stopwatch recursiveStopwatch = new Stopwatch();
recursiveStopwatch.Start();
recursiveResult = Utility.GreatestCommonDivisor(number1, number2);
recursiveStopwatch.Stop();
recursiveTime = recursiveStopwatch.ElapsedTicks;

// time the iterative gcd
Stopwatch iterativeStopwatch = new Stopwatch();
iterativeStopwatch.Start();
iterativeResult = Utility.GreatestCommonDivisorIterative(number1, number2);
iterativeStopwatch.Stop();
iterativeTime = iterativeStopwatch.ElapsedTicks;

// find gcd for three numbers
multipleResult = Utility.GreatestCommonDivisorMultiple(number1, number2, number3);

// print the results
Console.WriteLine();
Console.WriteLine($"Recursive GCD of {number1} and {number2} is {recursiveResult}");
Console.WriteLine($"Iterative GCD of {number1} and {number2} is {iterativeResult}");
Console.WriteLine($"GCD of {number1}, {number2}, and {number3} is {multipleResult}");
Console.WriteLine();
Console.WriteLine($"Recursive time: {recursiveTime} ticks");
Console.WriteLine($"Iterative time: {iterativeTime} ticks");

//------------------------------------------------------------
// End of the Main Method
//------------------------------------------------------------

//------------------------------------------------------------
// Start of the Utility Class
//------------------------------------------------------------
public class Utility
{
    /// <summary>
    /// Calculate the GCD using recursion
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    internal static int GreatestCommonDivisor(int num1, int num2)
    {
        // Declare and initialize
        int remainder = 0;

        // Base case: num2 is 0
        if (num1 == 0 || num2 == 0)
        {
            // Return the greatest common divisor
            return num1;
        }
        else
        {
            // Get the remainder of dividing num1 and num2
            remainder = num1 % num2;

            // Print an update to the user
            Console.WriteLine($"Not yet. The remainder of {num1} and {num2} is {remainder}");

            // Call the recursive function of the second number and the remainder
            return GreatestCommonDivisor(num2, remainder);
        }
    }

    // read an integer from the user
    internal static int ReadIntFromConsole()
    {
        string input = "";
        int number = 0;

        input = Console.ReadLine();

        while (!int.TryParse(input, out number))
        {
            Console.WriteLine("Invalid input. Please try again:");
            input = Console.ReadLine();
        }

        return number;
    }

    // find the gcd using a loop and lists
    internal static int GreatestCommonDivisorIterative(int num1, int num2)
    {
        // make negative numbers positive
        num1 = Math.Abs(num1);
        num2 = Math.Abs(num2);

        // handle cases with 0
        if (num1 == 0)
        {
            return num2;
        }

        if (num2 == 0)
        {
            return num1;
        }

        // store divisors for each number
        List<int> divisors1 = new List<int>();
        List<int> divisors2 = new List<int>();

        // find divisors for the first number
        for (int i = 1; i <= num1; i++)
        {
            if (num1 % i == 0)
            {
                divisors1.Add(i);
            }
        }

        // find divisors for the second number
        for (int i = 1; i <= num2; i++)
        {
            if (num2 % i == 0)
            {
                divisors2.Add(i);
            }
        }

        // find the largest common divisor
        int gcd = 1;

        foreach (int divisor in divisors1)
        {
            if (divisors2.Contains(divisor))
            {
                gcd = divisor;
            }
        }

        return gcd;
    }

    // find the gcd for three numbers
    internal static int GreatestCommonDivisorMultiple(int num1, int num2, int num3)
    {
        // use the first result with the third number
        int firstResult = GreatestCommonDivisorIterative(num1, num2);
        return GreatestCommonDivisorIterative(firstResult, num3);
    }
}
//------------------------------------------------------------
// End of the Utility Class
//------------------------------------------------------------
