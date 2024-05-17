namespace Assignment_3.Models;
using System.ComponentModel.DataAnnotations;

public enum OrderStatus
{
    Pending,
    InProgress,
    Done
}
public class Order
{
    [Key]
    public int OrderID { get; set; }
    public List<Item> Items { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
}