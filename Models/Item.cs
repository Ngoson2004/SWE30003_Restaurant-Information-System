namespace Assignment_3.Models;
using System.ComponentModel.DataAnnotations;

public class Item
{
    [Key]
    public int OrderItemID { get; set; }
    public int OrderID { get; set; }
    public Order Order { get; set; }
    public string ItemName { get; set; }
    public Menu Menu { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; } = "";
}
