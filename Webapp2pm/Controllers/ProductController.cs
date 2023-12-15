using Microsoft.AspNetCore.Mvc;
using Webapp2pm.Data.Repository.IRepository;
using Webapp2pm.Models;

namespace Webapp2pm.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _db;

        public ProductController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Product.GetAll(includeProperties: "Category");
            return View(products); ;
        }
    }
}
