#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lialikLartisana.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public int UserId { get; set; }
  
    [Required]
    public string ProductName { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    
    [Required]
    [Display(Name ="Free Shipping")]
    public bool FreeShipping { get; set; }

    [Required]
    public Category Category { get; set; }

    //Navigation Property
    public User? Seller { get; set; }
    
    public OrderProduct? OrderProduct {get; set;}

    public List<Images> Images {get; set;} = new();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public enum Category
{
    Painting,
    Wearable,
    Decoration,
    Sculpture,
    
}