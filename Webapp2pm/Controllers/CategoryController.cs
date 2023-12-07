using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Webapp2pm.Data;
using Webapp2pm.Models;

namespace Webapp2pm.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories =_db.Categories;
            return View(categories);
        }
    }
}
