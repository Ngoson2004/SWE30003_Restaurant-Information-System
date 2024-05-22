using Assignment_3.Data;
using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Assignment_3.Controllers;

public class ReservationController : Controller
{
    private readonly ApplicationDbContext _db;

    public ReservationController(ApplicationDbContext  db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        IEnumerable<Reserv> objReservList= _db.Reservations; 
        return View(objReservList);
    }

    //get
    public IActionResult CreateReserv()
    {
        return View();
    }

    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateReserv(Reserv obj)
    {
        if(ModelState.IsValid) 
        {
            _db.Reservations.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Reservation sucessfully placed.";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
}

