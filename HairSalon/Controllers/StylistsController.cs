using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
      private readonly HairSalonContext _db;

      public StylistsController(HairSalonContext db)
      {
        _db = db;
      }
      public ActionResult Index()
      {
        List<Stylist> stylists = _db.Stylists.ToList();
        return View(stylists);
      }
      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Stylist stylist)
      {
        stylist.StartDate = DateTime.Now;
        stylist.GenerateAppoinments();
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return Redirect($"/stylists/details/{stylist.StylistId}");
      }
      public ActionResult Details(int id)
      {
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        return View(stylist);
      }
      public ActionResult Edit(int id)
      {
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        return View(stylist);
      }
      [HttpPost]
      public ActionResult Edit(Stylist stylist)
      {
        _db.Entry(stylist).State = EntityState.Modified;
        _db.SaveChanges();
        return Redirect($"/stylists/details/{stylist.StylistId}");
      }
      [HttpPost]
      public ActionResult Delete(int id)
      {
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        foreach (Appointment appointment in stylist.Appointments)
        {
          _db.Appointments.Remove(appointment);
        }
        foreach (Client client in stylist.Clients)
        {
          _db.Clients.Remove(client);
        }
        _db.Stylists.Remove(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    }
}