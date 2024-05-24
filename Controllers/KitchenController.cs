using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Assignment_3.Models;
using Assignment_3.Data;

namespace Assignment_3.Controllers;

public class KitchenController : Controller
{
    private readonly ApplicationDbContext _db;
    public KitchenController(ApplicationDbContext db)
    {
        _db = db;

    }
    public IActionResult Index()
    {
        var orders = _db.Order
                        .Include(o => o.Items)
                        .ToList();
        // .ThenInclude(oi => oi.Menu)
        // .ToList();
        return View(orders);
    }

    [HttpPost]
    public IActionResult UpdateOrderStatus(int orderID, OrderStatus newStatus)
    {
        var order = _db.Order.Find(orderID);
        if (order != null)
        {
            order.Status = newStatus;
            _db.SaveChanges();
            TempData["success"] = "Status sucessfully updated.";
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Archieve(int orderID)
    {
        var order = _db.Order.Find(orderID);
        if (order != null)
        {
            //Remove all related items
            // _db.Item.RemoveRange(order.Items);
            _db.Order.Remove(order);
            _db.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}