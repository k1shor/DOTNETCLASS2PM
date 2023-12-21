using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.Claims;
using Utils;
using Webapp2pm.Data.Repository.IRepository;
using Webapp2pm.Models;

namespace Webapp2pm.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = StaticData.ROLE_CUSTOMER)]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _db;
        public ShoppingCartController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartViewModel shoppingCartVM = new()
            {
                shoppingCarts = _db.ShoppingCart.GetAll(u => u.UserID == userId, "Product").ToList(),
            };

            double total = 0;
            foreach(var item in shoppingCartVM.shoppingCarts)
            {
                total += item.Quantity * item.Product.Price;
            }

            return View(shoppingCartVM);
        }

        [HttpPost]
        public IActionResult AddToCart(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            shoppingCart.UserID = userId;

            var shoppingCartFromDb = _db.ShoppingCart.FirstOrDefault(u => u.productID == shoppingCart.productID && u.UserID == userId);

            if (shoppingCartFromDb != null)
            {
                shoppingCartFromDb.Quantity += shoppingCart.Quantity;
                _db.Save();
                TempData["success"] = "Quantity increased in cart.";
            }
            else
            {
                _db.ShoppingCart.Create(shoppingCart);
                _db.Save();
                TempData["success"] = "Item added to cart";
            }

            return RedirectToAction("Index");
        }
    }
}
