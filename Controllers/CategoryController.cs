using Microsoft.AspNetCore.Mvc;
using Shop.Data;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var categories = _context.Categories;
        return View(categories);
    }
}