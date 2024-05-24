namespace Assignment_3.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Assignment_3.Attributes;
public class Reserv
{
    [Key]
    public int ReservId {get; set;}
    [Required]
    [DisplayName("Customer Name")]
    public string CustomerName {get; set;}
    [Required]
    [DateRange]
    public DateTime Time { get; set; }

}