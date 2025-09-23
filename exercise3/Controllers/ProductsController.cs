using exercise3.Models;
using exercise3.Services;
using Microsoft.AspNetCore.Mvc;

namespace exercise3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly IProductService _productService;

  public ProductsController(IProductService productService)
  {
    _productService = productService;
  }

  [HttpGet]
  public ActionResult<IEnumerable<Product>> GetProducts()
  {
    var products = _productService.GetAllProducts();
    return Ok(products);
  }

  [HttpGet("{id}")]
  public ActionResult<Product> GetProduct(int id)
  {
    var product = _productService.GetProductById(id);
    if (product == null)
    {
      return NotFound();
    }
    return Ok(product);
  }

  [HttpPost]
  public ActionResult<Product> CreateProduct(Product product)
  {
    if (string.IsNullOrWhiteSpace(product.Name))
    {
      return BadRequest("Product name is required.");
    }

    if (product.Price <= 0)
    {
      return BadRequest("Product price must be greater than 0.");
    }

    var createdProduct = _productService.AddProduct(product);
    return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
  }

  [HttpPut("{id}")]
  public ActionResult<Product> UpdateProduct(int id, Product product)
  {
    if (string.IsNullOrWhiteSpace(product.Name))
    {
      return BadRequest("Product name is required.");
    }

    if (product.Price <= 0)
    {
      return BadRequest("Product price must be greater than 0.");
    }

    var updatedProduct = _productService.UpdateProduct(id, product);
    if (updatedProduct == null)
    {
      return NotFound();
    }

    return Ok(updatedProduct);
  }

  [HttpDelete("{id}")]
  public ActionResult DeleteProduct(int id)
  {
    var result = _productService.DeleteProduct(id);
    if (!result)
    {
      return NotFound();
    }

    return NoContent();
  }
}