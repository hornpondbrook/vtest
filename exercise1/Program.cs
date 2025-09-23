using System;

namespace exercise1
{
  class Program
  {
    static void Main(string[] args)
    {
      // Check if exactly two arguments are provided
      if (args.Length != 2)
      {
        Console.WriteLine("Error: Please provide exactly two integers as arguments.");
        Console.WriteLine("Usage: exercise1 <number1> <number2>");
        return;
      }

      // Try to parse the arguments as integers
      if (!int.TryParse(args[0], out int num1) || !int.TryParse(args[1], out int num2))
      {
        Console.WriteLine("Error: Both arguments must be valid integers.");
        Console.WriteLine("Usage: exercise1 <number1> <number2>");
        return;
      }

      // Validate input constraints
      if (num1 < 2)
      {
        Console.WriteLine("Error: First number must be at least 2.");
        return;
      }

      if (num1 >= 1000)
      {
        Console.WriteLine("Error: First number must be less than 1000.");
        return;
      }

      if (num1 < 0 || num2 < 0)
      {
        Console.WriteLine("Error: Negative inputs are not allowed.");
        return;
      }

      if (num2 == 0)
      {
        Console.WriteLine("Error: Division by zero is not allowed.");
        return;
      }

      if (num2 > num1)
      {
        Console.WriteLine("Error: Second number cannot be greater than first number.");
        return;
      }

      // Check if first number is not evenly divisible by second number
      if (num1 % num2 != 0)
      {
        Console.WriteLine($"Error: First number {num1} is not evenly divisible by second number {num2}.");
        return;
      }

      // Count backwards from first number to zero
      // Print numbers divisible by the second number
      bool firstNumber = true;

      for (int i = num1; i > 0; i--)
      {
        // Check if current number is divisible by the second number
        if (i % num2 == 0)
        {
          if (!firstNumber)
          {
            Console.Write(" ");
          }
          Console.Write(i);
          firstNumber = false;
        }
      }

      // Add new line at the end
      Console.WriteLine();
    }
  }
}
