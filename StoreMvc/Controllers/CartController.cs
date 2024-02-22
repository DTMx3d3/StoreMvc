using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreMvc.Data;
using StoreMvc.Models;
using StoreMvc.Services;
using System.Linq;
using System.Security.Claims;

namespace StoreMvc.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderService _orderService;


        public CartController(ApplicationDbContext context)
        {
            _context = context;
            _orderService = new OrderService(context);
        }

        public IActionResult Cart()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



            var cart = _context.Carts
          .Include(c => c.CartDetails)
          .ThenInclude(cd => cd.Watch)
          .FirstOrDefault(c => c.UserId == userId);


            return View(cart);
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int cartDetailId)
        {
            var cartDetail = _context.CartDetails.FirstOrDefault(cd => cd.Id == cartDetailId);
            if (cartDetail != null)
            {
                _context.CartDetails.Remove(cartDetail);
                _context.SaveChanges();
            }

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult CreateOrder()
        {
            var userId = User.Identity.Name;
            try
            {
                _orderService.CreateOrder(userId);
                return RedirectToAction("Index", "Order");
            }
            catch (Exception ex)
            {
               
                return View("OrderError");
            }
        }

    }
}
