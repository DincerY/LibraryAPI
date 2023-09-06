namespace OrderAPI.Models.Entities;

public class Product : BaseEntity
{
    public Guid BookId { get; set; }
    public string Name { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}