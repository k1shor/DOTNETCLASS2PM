﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils;
using Webapp2pm.Data.Repository.IRepository;
using Webapp2pm.Models;

namespace Webapp2pm.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =StaticData.ROLE_ADMIN)]
    public class CategoryController : Controller
    {
        //        private readonly ApplicationDbContext _db;
        //        private readonly ICategoryRepository _db;
        private readonly IUnitOfWork _db;

        //        public CategoryController(ApplicationDbContext db)
        //          public CategoryController(ICategoryRepository db)
        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //IEnumerable<Category> categories = _db.Categories;
            //IEnumerable<Category> categories = _db.GetAll();
            IEnumerable<Category> categories = _db.Category.GetAll();
            return View(categories);
        }
        [HttpGet]
        public IActionResult PostCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostCategory(Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                if (categoryObj.CategoryName.ToLower() == "test")
                {
                    ModelState.AddModelError("Category", "Test is not a valid category");
                    return View(categoryObj);
                }
                //_db.Categories.Add(categoryObj);
                //_db.SaveChanges();

                _db.Category.Create(categoryObj);
                _db.Save();


                TempData["success"] = "Category Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryObj);
            }
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            //            Category categoryObj = _db.Categories.Find(id);

            Category categoryObj = _db.Category.FirstOrDefault(u => u.CategoryID == id);
            return View(categoryObj);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                //_db.Categories.Update(categoryObj);
                //_db.SaveChanges();

                _db.Category.Update(categoryObj);
                _db.Save();

                TempData["Success"] = "Category Updated Successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryObj);
            }
        }
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {

            //Category categoryObj = _db.Categories.Find(id);
            Category categoryObj = _db.Category.FirstOrDefault(u => u.CategoryID == id);
            return View(categoryObj);
        }

        [HttpPost]
        [ActionName("DeleteCategory")]
        /*        public IActionResult Delete_Category(Category categoryObj)*/
        public IActionResult Delete_Category(int id)
        {
            //Category categoryObj = _db.Categories.Find(id);
            Category categoryObj = _db.Category.FirstOrDefault(u => u.CategoryID == id);

            if (categoryObj == null)
            {
                return NotFound();
            }
            //_db.Categories.Remove(categoryObj);
            //_db.SaveChanges();
            _db.Category.Delete(categoryObj);
            _db.Save();

            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
