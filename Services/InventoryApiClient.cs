using System.Net.Http.Json;
using InventoryHub.Models;

namespace InventoryHub.Services;

public class InventoryApiClient
{
    private readonly HttpClient _http;

    public InventoryApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ProductDto>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<ApiResponse>("api/products", cancellationToken);
            return response?.Items ?? new List<ProductDto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching products: {ex.Message}");
            return new List<ProductDto>();
        }
    }

    public async Task<ProductDto?> GetProductAsync(int id)
    {
        return await _http.GetFromJsonAsync<ProductDto>($"api/products/{id}");
    }

    public async Task<bool> CreateProductAsync(ProductDto product)
    {
        var response = await _http.PostAsJsonAsync("api/products", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProductAsync(int id, ProductDto product)
    {
        var response = await _http.PutAsJsonAsync($"api/products/{id}", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/products/{id}");
        return response.IsSuccessStatusCode;
    }

    private class ApiResponse
    {
        public int Count { get; set; }
        public List<ProductDto> Items { get; set; } = new();
    }
}