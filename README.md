# Verisk Test Solution

Two C# console applications built with .NET 9.0.

## Build

```bash
# Build entire solution
dotnet build

# Build specific project
dotnet build exercise1
dotnet build exercise2
```

## Run

### Exercise 1
Processes two integers and outputs divisible numbers counting backwards.

```bash
dotnet run --project exercise1 -- <number1> <number2>

# Example
dotnet run --project exercise1 -- 25 5
```

### Exercise 2  
Reads integers from file, squares them using parallel processing, writes to output file.

```bash
dotnet run --project exercise2 -- <input_file> <output_file>

# Example with sample data
dotnet run --project exercise2 -- Data/numbers.txt Data/output.txt
```

## Sample Data

Use `Data/numbers.txt` as input for Exercise 2.