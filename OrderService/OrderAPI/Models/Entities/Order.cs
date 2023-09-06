namespace OrderAPI.Models.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<Product> Products { get; set; }
}