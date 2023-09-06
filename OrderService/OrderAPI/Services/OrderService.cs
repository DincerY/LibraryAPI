using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderAPI.Models;
using OrderAPI.Models.Entities;

namespace OrderAPI.Services;

public class OrderService
{
    private readonly OrderAPIDbContext _context;

    public OrderService(OrderAPIDbContext context)
    {
        _context = context;
    }

    public async Task<Order> AddOrder(Order order)
    {
        EntityEntry<Order> orderEntity = _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return orderEntity.Entity;
    }
}