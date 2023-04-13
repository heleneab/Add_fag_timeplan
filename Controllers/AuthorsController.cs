using Microsoft.AspNetCore.Mvc;
using Example.Data;
using Example.Models;

namespace Example.Controllers;

public class AuthorsController : Controller
{
    // Added private field for the application db context
    private readonly ApplicationDbContext _db;
    
    // Constructor with db context as a parameter
    public AuthorsController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET
    public IActionResult Index()
    {
        // Fetch authors from the database
        var authors = _db.Authors.ToList();
        
        // Send the list to the view. The view declares its model as @model IEnumerable<Author> to match.
        return View(authors);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(new Author());
    }
    
    [HttpPost]
    public IActionResult Add(Author author)
    {
        if (!ModelState.IsValid)
            return View(author);

        _db.Authors.Add(author);
        _db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
}
