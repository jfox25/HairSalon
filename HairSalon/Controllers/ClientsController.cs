using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
      private readonly HairSalonContext _db;

      public ClientsController(HairSalonContext db)
      {
        _db = db;
      }
      public ActionResult Index()
      {
        List<Client> clients = _db.Clients.ToList();
        ViewBag.StylistCount = _db.Stylists.ToList().Count;
        return View(clients);
      }
      public ActionResult Create(int id)
      {
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
        if(id != 0)
        {
          Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
          ViewBag.StylistName = stylist.Name;
        }
        ViewBag.fromStylistId = id;
        return View();
      }
      [HttpPost]
      public ActionResult Create(Client client, string returnToStylist = "false")
      {
        _db.Clients.Add(client);
        _db.SaveChanges();
        if(returnToStylist == "true")
        {
          return Redirect($"/stylists/details/{client.StylistId}");
        }
        return RedirectToAction("Index");
      }
       public ActionResult Details(int id)
      {
        Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == client.StylistId);
        ViewBag.StylistName = stylist.Name;
        return View(client);
      }
       public ActionResult Edit(int id)
      {
        Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
        return View(client);
      }
      [HttpPost]
      public ActionResult Edit(Client client)
      {
        _db.Entry(client).State = EntityState.Modified;
        _db.SaveChanges();
        return Redirect($"/clients/details/{client.ClientId}");
      }
      [HttpPost]
      public ActionResult Delete(int id)
      {
        Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        foreach (Appointment appointment in client.Appointments)
        {
          if(appointment.IsBooked)
          {
            appointment.IsBooked = false;
            appointment.ClientId = 0;
            _db.Entry(appointment).State = EntityState.Modified;
          }
        }
        _db.Clients.Remove(client);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    }
}