#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lialikLartisana.Models;

public class OrderProduct
{
    public int OrderProductId {get; set;}
    public int OrderId {get; set;}

    public int ProductId { get; set; }

    public Order? Orders {get; set;}
    public List<Product> ProductsInCart { get; set; } = new();

}