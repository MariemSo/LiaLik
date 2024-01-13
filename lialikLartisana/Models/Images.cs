#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lialikLartisana.Models;

public class Images{
    
    [Key]
    public int ImageId { get; set; }

    [Required]
    public int ProductId {get; set;}


    [DataType(DataType.Url,ErrorMessage ="Please enter a valid Url")]
    public string ImageUrl{get;set;}

    public Product? ProductImages {get; set;}
}