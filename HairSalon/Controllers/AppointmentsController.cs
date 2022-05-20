using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class AppointmentsController : Controller
    {
      private readonly HairSalonContext _db;

      public AppointmentsController(HairSalonContext db)
      {
        _db = db;
      }
      public ActionResult Index()
      {
        List<Appointment> appointments = _db.Appointments.ToList();
        ViewBag.StylistCount = _db.Stylists.ToList().Count;
        ViewBag.ClientsCount = _db.Clients.ToList().Count;
        return View(appointments);
      }

    }
}