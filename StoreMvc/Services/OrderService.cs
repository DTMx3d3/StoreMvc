using Microsoft.EntityFrameworkCore;
using StoreMvc.Data;
using StoreMvc.Models;
using System;
using System.Linq;
namespace StoreMvc.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(string userId)
        {
            
            var cart = _context.Carts
                .Include(c => c.CartDetails)
                    .ThenInclude(cd => cd.Watch)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null || cart.CartDetails.Count == 0)
            {
              
                throw new InvalidOperationException("Cannot create order because the cart is empty.");
            }

            var order = new Order
            {
                userId = userId,
                orderDate = DateTime.Now,
               
                payType = "Credit Card"
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var cartDetail in cart.CartDetails)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    WatchId = cartDetail.WatchId,
                    Quantity = cartDetail.Quantity
                };

                _context.OrderDetails.Add(orderDetail);
            }

            _context.CartDetails.RemoveRange(cart.CartDetails);
            _context.SaveChanges();
        }
    }
}
