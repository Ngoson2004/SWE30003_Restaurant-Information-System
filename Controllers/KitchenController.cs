using System.Diagnostics;
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
                             .ThenInclude(oi => oi.Menu)
                             .ToList();
        return View(orders);
    }
}