#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations; //for validation 
using System.ComponentModel.DataAnnotations.Schema; //new Import for table
namespace lialikLartisana.Models;

public class LoginUser
{
    [Required(ErrorMessage = "Please enter your Email")]
    [EmailAddress(ErrorMessage = "Please enter a valid Email")]
    [Display(Name = "Email")]
    public string LoginEmail { get; set; }
    

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [Display(Name = "Password")]
    public string LoginPassword { get; set; }
      
}