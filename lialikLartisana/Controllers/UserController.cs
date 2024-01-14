using  lialikLartisana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace lialikLartisana.Controllers;

public class UserController : Controller
{
    private readonly MyContext _context;
    public UserController(MyContext context)
    {
        _context = context;
    }
    [HttpGet("user/logreg")]
    public IActionResult LogReg()
    {
        return View("LogReg");
        
    }
    //-----------------Register Action----------------
    [HttpPost("users/create")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            	//Check if Email exists
                if (_context.Users.Any(u => u.Email== newUser.Email))//Any returns true or false
                {
                    //if True
                    ModelState.AddModelError("Email"," already in use.");
                    return View("LogReg");
                }
                else
                {
                        //if False
                        //Hashing Password
                        PasswordHasher<User> Hasher = new PasswordHasher<User>();
                        newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                        //add
                        _context.Add(newUser);
                        //save
                        _context.SaveChanges();
                        //protect privacy page by adding userid to session
                        HttpContext.Session.SetInt32("userId", newUser.UserId);
                        HttpContext.Session.SetString("username", newUser.FirstName);
                    return RedirectToAction ("ShowAll","Products");
                }
        }
        return View("LogReg");
     }
 //-----------------Login Action------------------------
    [HttpPost("user/login")]
    public IActionResult Login(LoginUser loginUser)
    {   
        //Validate first
        if (ModelState.IsValid)
        {
            //Check if Email Exist
            User? userFormDb = _context.Users.FirstOrDefault(u=>u.Email == loginUser.LoginEmail);
            if (userFormDb is null)
            {
                ModelState.AddModelError("LoginEmail","Wrong Credentials!");
                return View("LogReg");
            }
            else//Check Password
            {
                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();
                    
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(loginUser, userFormDb.Password, loginUser.LoginPassword);
                    
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("LoginEmail","Wrong Credantial!");
                    return View("LogReg");
                }
                else
                {
                    HttpContext.Session.SetInt32("userId", userFormDb.UserId);
                    HttpContext.Session.SetString("username", userFormDb.FirstName);
                    return RedirectToAction("ShowAll","Products");
                }
            }
            
        }
        return View("LogReg");
    }
    //------------LogOut Action-----------
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("index");
    }


}