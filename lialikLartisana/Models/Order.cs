#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lialikLartisana.Models;

public class Order{
    
    [Key]
    public int OrderId { get; set; }
    public int UserId {get; set;}
    public User? Buyer {get; set;}

     public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();    
}