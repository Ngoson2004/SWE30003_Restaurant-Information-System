namespace Assignment_3.Models;
using System.ComponentModel.DataAnnotations;
public class Statistics
{
    [Key]
    public int OrderID { get; set; }
    public Order Order { get; set; }
    public float TotalPrice { get; set; }
    public string? Feedback { get; set; }
}