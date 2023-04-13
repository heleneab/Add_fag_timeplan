using Microsoft.AspNetCore.Mvc;
using Example.Data;
using Example.Models;
namespace Example.Controllers;

public class AvalebleController : Controller
{
    // Added private field for the application db context
    private readonly ApplicationDbContext _db;
    
    // Constructor with db context as a parameter
    public AvalebleController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET
    public IActionResult Index()
    {
        // Fetch authors from the database
        var avalebles = _db.Avalebles.ToList();
        
        // Send the list to the view. The view declares its model as @model IEnumerable<Author> to match.
        return View(avalebles);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View(new Avaleble());
    }
    
    [HttpPost]
    public IActionResult Add(Avaleble avaleble)
    {
        if (!ModelState.IsValid)
            return View(avaleble);

        _db.Avalebles.Add(avaleble);
        _db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
}