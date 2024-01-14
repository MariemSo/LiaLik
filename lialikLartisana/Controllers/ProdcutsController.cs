using  lialikLartisana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace lialikLartisana.Controllers;

public class ProductsController : Controller
{
    private readonly MyContext _context;
    public ProductsController(MyContext context)
    {
        _context = context;
    }

    //------------ShowAll------------
    [HttpGet("products")]
    public IActionResult ShowAll()
    { 
        List<Product> AllProducts = _context.Products.Include(p => p.Seller).ToList();
        return View(AllProducts);
    }
    //------------AddProduct------------
    //Display
    [HttpGet("products/new")]
    public IActionResult AddProduct()
    {
        //checking if user is logged in
        if (HttpContext.Session.GetInt32("userId")== null)
        {
            return RedirectToAction("LogReg","User");
        }
        return View("AddProduct");
    }
    //Create
    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
                _context.Add(newProduct);
                _context.SaveChanges();
            return RedirectToAction("LogReg", "User");
        }
        return View("AddProduct");
    }
    //----------ShowCraft-----------
    [HttpGet("products/{ProductId}")]
    public IActionResult ShowOne(int ProductId)
    {
        Product? oneProduct = _context.Products
        .Include(Product => Product.Seller)
        .FirstOrDefault(Product => Product.ProductId == ProductId);
        return View(oneProduct);
    }
}