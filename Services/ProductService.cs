using InventoryHub.Server.Models;

namespace InventoryHub.Server.Services;

public class ProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public ProductService()
    {
        _products.Add(new Product { Id = _nextId++, Name = "Laptop", Price = 1200.00m, Stock = 15, Category = "Electronics" });
        _products.Add(new Product { Id = _nextId++, Name = "Desk Chair", Price = 250.00m, Stock = 8, Category = "Furniture" });
        _products.Add(new Product { Id = _nextId++, Name = "Notebook", Price = 5.99m, Stock = 200, Category = "Stationery" });
    }

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public Product Create(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }

    public bool Update(int id, Product updated)
    {
        var existing = GetById(id);
        if (existing == null) return false;

        existing.Name = updated.Name;
        existing.Price = updated.Price;
        existing.Stock = updated.Stock;
        existing.Category = updated.Category;
        return true;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);
        if (product == null) return false;
        _products.Remove(product);
        return true;
    }
}