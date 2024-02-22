using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreMvc.Data;
using StoreMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace StoreMvc.Controllers
{
    public class AllWatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllWatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AllWatches()
        {
            List<Watch> watches = _context.Watches.ToList();
            return View(watches);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int watchId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

           
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
            }

            // adaugare in cos
            cart.CartDetails.Add(new CartDetail { WatchId = watchId, Quantity = 1 });
            _context.SaveChanges();

            return RedirectToAction("AllWatches"); 
        }
    }
}
