
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
  public static void Main(string[] args)
  {
    // 1. Validate command-line arguments
    if (args.Length != 2)
    {
      Console.WriteLine("Usage: Exercise2_MultiThreading.exe <input_file_path> <output_file_path>");
      return;
    }

    string inputFilePath = args[0];
    string outputFilePath = args[1];

    // Ensure the data directory exists
    string outputDirectory = Path.GetDirectoryName(outputFilePath);
    if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
    {
      Directory.CreateDirectory(outputDirectory);
    }

    try
    {
      // 2. Read all lines from the input file
      Console.WriteLine($"Reading numbers from: {inputFilePath}");
      var numbers = File.ReadAllLines(inputFilePath)
                        .Select(int.Parse) // Convert each line to an integer
                        .ToList();

      // 3. Process the numbers in parallel
      var squaredNumbers = new ConcurrentBag<int>();

      Console.WriteLine("Processing numbers in parallel...");
      Parallel.ForEach(numbers, number =>
      {
        int result = number * number;
        squaredNumbers.Add(result); // Add the result to our thread-safe collection.
      });

      // 4. Sort and write the squared numbers to the output file
      Console.WriteLine($"Writing results to: {outputFilePath}");
      var sortedResults = squaredNumbers.OrderBy(n => n).Select(n => n.ToString());
      File.WriteAllLines(outputFilePath, sortedResults);

      Console.WriteLine("Processing complete. The squared numbers have been written.");
    }
    catch (FileNotFoundException)
    {
      Console.WriteLine($"Error: The file '{inputFilePath}' was not found.");
    }
    catch (FormatException)
    {
      Console.WriteLine("Error: The input file contains non-integer values.");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    }
  }
}