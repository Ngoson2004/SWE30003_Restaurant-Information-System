using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Assignment_3.Models;
using Assignment_3.Data;

namespace Assignment_3.Controllers;
public class MenuController : Controller
{
    private readonly ApplicationDbContext _db;

    public MenuController(ApplicationDbContext db)
    {
        _db = db;

    }

    //GET method - display the menu
    public IActionResult Index()
    {
        IEnumerable<Menu> items = _db.Menu;
        return View(items);
    }

    //POST method - create the orders
    [HttpPost]
    public IActionResult Create(Order order, List<Item> items)
    {

        foreach (var item in items.Where(oi => oi.Quantity > 0))
        {
            var menuItem = _db.Menu.FirstOrDefault(m => m.ItemName == item.ItemName);
            if (menuItem != null)
            {
                item.ItemName = menuItem.ItemName; // Ensure ItemName is set correctly
                order.Items.Add(item);
            }
        }
        _db.Order.Add(order);
        _db.SaveChanges();

        // return RedirectToAction("Feedback");

        var menuItems = _db.Menu.ToList();
        return View("Index", menuItems);
    }

    public IActionResult Feedback()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}