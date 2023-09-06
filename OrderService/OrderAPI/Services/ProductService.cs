using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderAPI.Models;
using OrderAPI.Models.Entities;

namespace OrderAPI.Services;

public class ProductService
{
    private readonly OrderAPIDbContext _context;

    public ProductService(OrderAPIDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> AddRangeProduct(Guid[] bookIds,Guid orderId)
    {
        List<Product> products = new();
        foreach (var bookId in bookIds)
        {
            Product product = new()
            {
                BookId = bookId,
                OrderId = orderId,
                Name = ""
            };
            products.Add(product);
        }

        await _context.Products.AddRangeAsync(products);
        await _context.SaveChangesAsync();
        return products;

    }

}