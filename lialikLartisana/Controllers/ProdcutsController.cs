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
        List<Product> AllProducts = _context.Products.Include(s=>s.Seller).Include(i=>i.Images).ToList();
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
                System.Console.WriteLine(newProduct.UserId);
                _context.Add(newProduct);
                _context.SaveChanges();
            return RedirectToAction("ShowAll");
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
    //Delete Product
     [HttpPost("Product/delete")]
    public IActionResult DeleteProduct (int ProductId)
    {
        Product? ProductToDelete = _context.Products.SingleOrDefault(w => w.ProductId == ProductId);

            if (ProductToDelete == null)
            {
                // Handle this case differently, show an error message, or redirect to an error page
                return RedirectToAction("ShowAll");
            }

            // Check if the user deleting is the one logged in
            if (ProductToDelete.UserId != HttpContext.Session.GetInt32("userId"))
            {
                return RedirectToAction("ShowAll");
            }

            _context.Products.Remove(ProductToDelete);
            _context.SaveChanges();

            // Redirect to the Product list or another appropriate action
            return RedirectToAction("ShowAll");
    }
    [HttpGet("products/{ProductId}/edit")]
    public IActionResult EditProduct(int ProductId)
    {
        Product? ProductToEdit = _context.Products
            .SingleOrDefault(d => d.ProductId == ProductId);
        return View( ProductToEdit);
    }
    [HttpPost("/products/update/{ProductId}")]
    public IActionResult UpdateProduct(int ProductId, Product newestProduct)
    {
        Product? oldProduct = _context.Products.FirstOrDefault(b => b.ProductId ==ProductId);
         if (ModelState.IsValid)
        {
            oldProduct.ProductName = newestProduct.ProductName;
            oldProduct.Category = newestProduct.Category;
            oldProduct.Description = newestProduct.Description;
            oldProduct.Price = newestProduct.Price;
            oldProduct.FreeShipping = newestProduct.FreeShipping;
            oldProduct.UpdatedAt = newestProduct.UpdatedAt;
            _context.SaveChanges();

            return RedirectToAction("Products",newestProduct);
        }
        return View("EditProduct", oldProduct);

    }
}