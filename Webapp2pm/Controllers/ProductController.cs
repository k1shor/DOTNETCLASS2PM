using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webapp2pm.Data.Repository.IRepository;
using Webapp2pm.Models;

namespace Webapp2pm.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Product.GetAll(includeProperties: "Category");
            return View(products); ;
        }


        [HttpGet]
        public IActionResult UpsertProduct(int? id)
        {
            ProductViewModel productViewModel;
            IEnumerable<SelectListItem> categoryList = _db.Category.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryID.ToString()
                });
            if (id == 0 || id == null)
            {
                productViewModel = new ProductViewModel()
                {
                    product = new Product(),
                    categoryList = categoryList
                };
            }
            else
            {
                productViewModel = new ProductViewModel()
                {
                    product = _db.Product.FirstOrDefault(u => u.Id == id),
                    categoryList = categoryList
                };
            }
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult UpsertProduct(ProductViewModel productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRoot = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(wwwRoot, @"Images\Products", filename);

                    if (!string.IsNullOrEmpty(productVM.product.ImageUrl))
                    {
                        var oldFilePath = Path.Combine(wwwRoot, productVM.product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    productVM.product.ImageUrl = @"\Images\Products\" + filename;
                }


                if (productVM.product.Id == 0)
                {
                    _db.Product.Create(productVM.product);
                    _db.Save();
                    TempData["success"] = "Product Added Successfully";
                }
                else
                {
                    _db.Product.Update(productVM.product);
                    _db.Save();
                    TempData["success"] = "Product Updated Successfully";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(productVM);
            }
        }
    }
}


