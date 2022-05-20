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
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      public ActionResult Details(int id)
      {
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        return View(stylist);
      }

    }
}