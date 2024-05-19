using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Create(List<Item> items)
    {
        //Debug any invalidation
        if (!ModelState.IsValid)
        {
            //Log the validation errors
            foreach (var state in ModelState)
            {
                var key = state.Key;
                var errors = state.Value.Errors;
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error in {key}: {error.ErrorMessage}");
                }
            }

            // If validation fails, redisplay the form
            var i = _db.Menu.ToList();
            return View("Index", i);
        }


        var selectedItems = items.Where(i => i.IsSelected && i.Quantity > 0).ToList();
        //Debug the receivation of items
        // Console.WriteLine(selectedItems.Any());
        // foreach (var item in items)
        // {
        //     Console.WriteLine("selected: " + item.IsSelected + item.Quantity);
        // }
        // Console.WriteLine(ModelState.IsValid);

        if (selectedItems.Any())
        {
            var order = new Order
            {
                Items = selectedItems.Select(i => new Item
                {
                    ItemName = i.ItemName,
                    Quantity = i.Quantity,
                    Note = i.Note
                }).ToList()
            };

            _db.Order.Add(order);
            _db.SaveChanges();

            return RedirectToAction("Feedback");
            // foreach (var item in items.Where(oi => oi.Quantity > 0))
            // {
            //     var menuItem = _db.Menu.FirstOrDefault(m => m.ItemName == item.ItemName);
            //     if (menuItem != null)
            //     {
            //         item.ItemName = menuItem.ItemName; // Ensure ItemName is set correctly
            //         order.Items.Add(item);
            //     }
            // }
            // _db.Order.Add(order);
            // _db.SaveChanges();
            // }
        }

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