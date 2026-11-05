using System.ComponentModel.DataAnnotations;

namespace InventoryHub.Server.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 1_000_000, ErrorMessage = "Price must be positive")]
    public decimal Price { get; set; }

    [Range(0, 100_000, ErrorMessage = "Stock must be 0 or greater")]
    public int Stock { get; set; }

    public string Category { get; set; } = "General";
}