using Microsoft.AspNetCore.Mvc;
using OrderApi.Data;
using OrderApi.Models;

namespace OrderApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderDbContext _context;

    public OrdersController(
        OrderDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
       return Ok(
            _context.Orders
                .OrderByDescending(x => x.CreatedDate).ToList());      
    }

    [HttpPost]
    public IActionResult CreateOrder(
        Order order)
    {
        order.Id = Guid.NewGuid();
        order.CreatedDate =
            DateTime.UtcNow;

        _context.Orders.Add(order);
        _context.SaveChanges();

        return Ok(order);
    }
}