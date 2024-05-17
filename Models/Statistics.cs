namespace Assignment_3.Models;
public class Statistics
{
    public int OrderID { get; set; }
    public Order Order { get; set; }
    public float TotalPrice { get; set; }
    public string Feedback { get; set; }
}