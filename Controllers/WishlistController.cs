using Group6_Fashion_Merchandise.Data;
using Group6_Fashion_Merchandise.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Group6_Fashion_Merchandise.Controllers
{
    public class WishlistController : Controller
    {
        private readonly ProductContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishlistController(ProductContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // View Wishlist
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var items = await _context.WishlistItems
                                      .Include(w => w.Product)
                                      .Where(w => w.UserId == user.Id)
                                      .ToListAsync();

            return View(items);
        }

        // Add item to wishlist
        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            bool alreadyAdded = await _context.WishlistItems
                                              .AnyAsync(w => w.ProductId == productId && w.UserId == user.Id);

            if (!alreadyAdded)
            {
                var item = new WishlistItem
                {
                    ProductId = productId,
                    UserId = user.Id
                };

                _context.WishlistItems.Add(item);
                await _context.SaveChangesAsync();
            }

            // Redirect back to the previous page
            string referer = Request.Headers["Referer"].ToString();
            return Redirect(string.IsNullOrEmpty(referer) ? Url.Action("Index", "Product") : referer);
        }

        // Remove item from wishlist
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _context.WishlistItems.FindAsync(id);
            if (item != null)
            {
                _context.WishlistItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
