namespace Assignment_3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Statistics
{
    // [ForeignKey("Order")]
    public int OrderID { get; set; }
    // public Order? Order { get; set; }
    public float TotalPrice { get; set; }
    [Required]
    public string Feedback { get; set; }
}