using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ProductController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                product.UserId = currentUser.Id;
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
        return View(product);
    }
}