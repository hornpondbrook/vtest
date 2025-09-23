using exercise3.Models;

namespace exercise3.Services;

public interface IProductService
{
  IEnumerable<Product> GetAllProducts();
  Product? GetProductById(int id);
  Product AddProduct(Product product);
  Product? UpdateProduct(int id, Product product);
  bool DeleteProduct(int id);
}

public class ProductService : IProductService
{
  private readonly List<Product> _products;
  private int _nextId = 1;

  public ProductService()
  {
    _products = new List<Product>
        {
            new Product { Id = _nextId++, Name = "Laptop", Price = 999.99m, Description = "High-performance laptop" },
            new Product { Id = _nextId++, Name = "Mouse", Price = 29.99m, Description = "Wireless computer mouse" },
            new Product { Id = _nextId++, Name = "Keyboard", Price = 79.99m, Description = "Mechanical keyboard" }
        };
  }

  public IEnumerable<Product> GetAllProducts()
  {
    return _products;
  }

  public Product? GetProductById(int id)
  {
    return _products.FirstOrDefault(p => p.Id == id);
  }

  public Product AddProduct(Product product)
  {
    product.Id = _nextId++;
    _products.Add(product);
    return product;
  }

  public Product? UpdateProduct(int id, Product product)
  {
    var existingProduct = GetProductById(id);
    if (existingProduct == null)
      return null;

    existingProduct.Name = product.Name;
    existingProduct.Price = product.Price;
    existingProduct.Description = product.Description;

    return existingProduct;
  }

  public bool DeleteProduct(int id)
  {
    var product = GetProductById(id);
    if (product == null)
      return false;

    _products.Remove(product);
    return true;
  }
}