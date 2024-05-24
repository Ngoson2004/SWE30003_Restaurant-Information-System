namespace Assignment_3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Item
{
    [Key]
    public int OrderItemID { get; set; }
    public string ItemName { get; set; }
    public bool IsSelected { get; set; }
    [Range(0, 10, ErrorMessage = "Maximum quantity is 10")]
    public int Quantity { get; set; }
    public string? Note { get; set; }
    [ForeignKey("Order")]
    public int OrderID { get; set; } // Foreign key property
    public Order? Order { get; set; } // Navigation property
}
