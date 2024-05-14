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

    public IActionResult Index()
    {
        var items = _db.Menu.ToList();
        return View(items);
    }
}