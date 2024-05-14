namespace Assignment_3.Models;
using System.ComponentModel.DataAnnotations;

public class Menu
{
    // Menu table attributes
    [Key]
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public float ItemPrice { get; set; }
}
