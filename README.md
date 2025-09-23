# Verisk Test Solution

Three C# applications built with .NET 9.0.

## Build

```bash
# Build entire solution
dotnet build

# Build specific project
dotnet build exercise1
dotnet build exercise2
dotnet build exercise3
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

### Exercise 3
REST API for managing products with CRUD operations.

```bash
dotnet run --project exercise3
```

API will be accessible at: http://localhost:5100

#### Accessing the API

**Swagger UI (Interactive Documentation):**
- Open your browser and navigate to: http://localhost:5100/swagger/index.html
- This provides an interactive interface to test all API endpoints

**Using curl commands:**
```bash
# Get all products
curl http://localhost:5100/api/products

# Get specific product by ID
curl http://localhost:5100/api/products/1

# Create new product
curl -X POST -H "Content-Type: application/json" -d '{"name":"Product Name","price":99.99,"description":"Product description"}' http://localhost:5100/api/products

# Update product
curl -X PUT -H "Content-Type: application/json" -d '{"name":"Updated Name","price":149.99,"description":"Updated description"}' http://localhost:5100/api/products/1

# Delete product
curl -X DELETE http://localhost:5100/api/products/1
```

#### Endpoints
- **GET** `/api/products` - Returns all products
- **GET** `/api/products/{id}` - Returns a specific product
- **POST** `/api/products` - Adds a new product
- **PUT** `/api/products/{id}` - Updates a product
- **DELETE** `/api/products/{id}` - Deletes a product

## Sample Data

Use `Data/numbers.txt` as input for Exercise 2.