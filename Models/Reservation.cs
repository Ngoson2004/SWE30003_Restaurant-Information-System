namespace Assignment_3.Models;
using System.ComponentModel.DataAnnotations;
public class Reserv
{
    [Key]
    public int ReservId {get; set;}
    public string CustomerName {get; set;}
    
}