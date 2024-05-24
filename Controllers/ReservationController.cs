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

    //get
    public IActionResult Delete(int? id)
    {
        if (id == null || id== 0)
        {
            return NotFound();
        }

        var ReservationFromDB = _db.Reservations.Find(id);

        if(ReservationFromDB == null)
        {
            return NotFound();
        }

        return View(ReservationFromDB);
    }

    //post

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id) 
    {
        var obj = _db.Reservations.Find(id);
        if(obj == null) 
        {
            return NotFound();
        }
        _db.Reservations.Remove(obj);
        _db.SaveChanges();
        TempData["remove"] = "Reservation sucessfully removed.";
        return RedirectToAction("Index");
    }
}

