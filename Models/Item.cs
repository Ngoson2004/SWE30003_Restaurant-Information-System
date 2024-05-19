namespace Assignment_3.Models;
using System.ComponentModel.DataAnnotations;

public class Item
{
    [Key]
    public int OrderItemID { get; set; }
    public string ItemName { get; set; }
    public bool IsSelected { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
}
