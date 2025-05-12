using Group6_Fashion_Merchandise.Data;
using Group6_Fashion_Merchandise.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Group6_Fashion_Merchandise.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ProductContext _context;
        private const string CartKey = "Cart";

        public CartController(ProductContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var cart = GetCart();
            ViewBag.Total = cart.Sum(item => item.SubTotal);
            ViewBag.Tax = ViewBag.Total * 0.13M;
            ViewBag.GrandTotal = ViewBag.Total + ViewBag.Tax;
            return View(cart);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            var cart = GetCart();
            var existing = cart.FirstOrDefault(c => c.ProductId == id);

            if (existing != null)
                existing.Quantity += quantity;
            else
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    ImagePath = product.ImagePath
                });

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        
        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        
        public IActionResult Clear()
        {
            HttpContext.Session.Remove(CartKey);
            return RedirectToAction("Index");
        }

        
        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["Message"] = "Cart is empty.";
                return RedirectToAction("Index");
            }

            ViewBag.CartItems = cart; 
            ViewBag.Total = cart.Sum(i => i.SubTotal);
            ViewBag.Tax = ViewBag.Total * 0.13M;
            ViewBag.GrandTotal = ViewBag.Total + ViewBag.Tax;

            return View(new CheckoutViewModel());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            var cart = GetCart();

            if (!cart.Any())
            {
                TempData["Message"] = "Cart is empty.";
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.CartItems = cart;
                ViewBag.Total = cart.Sum(i => i.SubTotal);
                ViewBag.Tax = ViewBag.Total * 0.13M;
                ViewBag.GrandTotal = ViewBag.Total + ViewBag.Tax;

                return View(model);
            }

            

            HttpContext.Session.Remove(CartKey); 
            TempData["Success"] = "Order placed successfully!";
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        
        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartKey);
            return string.IsNullOrEmpty(cartJson)
                ? new List<CartItem>()
                : JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
        }

        private void SaveCart(List<CartItem> cart)
        {
            var json = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString(CartKey, json);
        }
    }
}
