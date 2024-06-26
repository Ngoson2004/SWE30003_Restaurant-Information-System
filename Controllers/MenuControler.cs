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

        if (!selectedItems.Any())
        {
            ModelState.AddModelError(string.Empty, "Please select at least one item.");
            var Items = _db.Menu.ToList();
            return View("Index", Items);
        }

        //calculate the total price of the last order
        var totalPrice = selectedItems.Sum(i => i.Quantity * _db.Menu.First(m => m.ItemName == i.ItemName).ItemPrice);

        var order = new Order
        {
            Items = selectedItems.Select(i => new Item
            {
                ItemName = i.ItemName,
                Quantity = i.Quantity,
                Note = i.Note
            }).ToList(),
            
        };

        _db.Order.Add(order);
        _db.SaveChanges();

        var statistics = new Statistics
        {
            TotalPrice = totalPrice,
            OrderID = order.OrderID
        };  //Update the statistics with total price

        return RedirectToAction("Feedback", statistics);
    }

    //Give Feedback functionality
    public IActionResult Feedback(int orderId, float totalPrice)
    {
        var statistics = new Statistics
        {
            OrderID = orderId,
            TotalPrice = totalPrice
        };
        return View(statistics);
    }

    [HttpPost]
    public IActionResult SubmitFeedback(Statistics model)
    {
        if (!ModelState.IsValid)
        {
            foreach (var state in ModelState)
            {
                var key = state.Key;
                var errors = state.Value.Errors;
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error in {key}: {error.ErrorMessage}");
                }
            }
            return View("Feedback", model);
        }
        _db.Stats.Add(model);   //Add new Feedback to the statistics
        _db.SaveChanges();

        return RedirectToAction("Index", "Home");   //After sending feedback, redirect to Home page
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}