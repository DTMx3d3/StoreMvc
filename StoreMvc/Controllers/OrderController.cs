using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreMvc.Data;
using StoreMvc.Models;
using System.Security.Claims;

public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Order()
    {
        var orders = _context.Orders.ToList();
        return View(orders);
    }

    [HttpPost]
    public IActionResult CreateOrder()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

       //obtinere cart pentru user
        var cart = _context.Carts
            .Include(c => c.CartDetails)
            .ThenInclude(cd => cd.Watch)
            .FirstOrDefault(c => c.UserId == userId);

        if (cart == null || cart.CartDetails.Count == 0)
        {
           
            return RedirectToAction("OrderError");
        }

        try
        {
            var order = new Order
            {
                userId = userId,
                orderDate = DateTime.Now,
                payType = "Ramburs" 
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            _context.CartDetails.RemoveRange(cart.CartDetails);
            _context.SaveChanges();

            return RedirectToAction("Order");
        }
        catch (Exception ex)
        {
            return RedirectToAction("OrderError");
        }
    }
}



