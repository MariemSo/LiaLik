#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lialikLartisana.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Please enter your First name")]
    [MinLength(2,ErrorMessage ="First name must be at least 2 characters long")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your Last name")]
    [MinLength(2,ErrorMessage ="Last name must be at least 2 characters long")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your Email")]
    [DataType(DataType.EmailAddress, ErrorMessage ="Please enter a valid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Password, ErrorMessage ="Please enter a valid password")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Please enter your password again")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now; 

    //Navigation Property
    public List<Product>MyProducts {get; set;} = new();
    public List<Order>MyOrders {get; set;}= new();

}