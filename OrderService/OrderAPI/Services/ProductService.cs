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

    public async Task<int> AddRangeProduct(Guid[] bookIds, Order order)
    {
        List<Product> products = new();
        foreach (var bookId in bookIds)
        {
            Product product = new()
            {
                BookId = bookId,
                OrderId = order.Id,
                Name = ""
            };
            products.Add(product);
        }

        await _context.Products.AddRangeAsync(products);
        return await _context.SaveChangesAsync();





    }

}