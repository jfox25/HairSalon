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
        List<Appointment> bookedAppointments = new List<Appointment>(){};
        foreach (Appointment appointment in appointments)
        {
          if(appointment.IsBooked)
          {
            bookedAppointments.Add(appointment);
          }
        }
        ViewBag.StylistCount = _db.Stylists.ToList().Count;
        ViewBag.ClientsCount = _db.Clients.ToList().Count;
        return View(bookedAppointments);
      }
      public ActionResult Create(int id) 
      {
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        List<Appointment> notBookedAppointments = new List<Appointment>(){};
        foreach (Appointment appointment in stylist.Appointments)
        {
          if(!appointment.IsBooked)
          {
            notBookedAppointments.Add(appointment);
          }
        }
        ViewBag.ClientId = new SelectList(stylist.Clients, "ClientId", "Name");
        ViewBag.AppointmentId = new SelectList(notBookedAppointments, "AppointmentId", "Time");
        ViewBag.StylistName = stylist.Name;
        return View();
      }
      [HttpPost]
      public ActionResult Create(int clientId, int appointmentId) 
      {
        Appointment appointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == appointmentId);
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == appointment.StylistId);
        stylist.UpdateTotalRevenue();
         _db.Entry(stylist).State = EntityState.Modified;
        appointment.IsBooked = true;  
        appointment.ClientId = clientId;
        _db.Entry(appointment).State = EntityState.Modified;
        _db.SaveChanges();
        return Redirect($"/stylists/details/{appointment.StylistId}");
      }

      public ActionResult Details(int id) 
      {
        Appointment appointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == appointment.StylistId);
        Client client = _db.Clients.FirstOrDefault(client => client.ClientId == appointment.ClientId);
        ViewBag.StylistName = stylist.Name;
        ViewBag.ClientName = client.Name;
        return View(appointment);
      }
      [HttpPost]
      public ActionResult Delete(int id) 
      {
        Appointment appointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
        Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == appointment.StylistId);
        stylist.UpdateLostTotalRevenue();
         _db.Entry(stylist).State = EntityState.Modified;
        if(appointment.IsBooked)
        {
          appointment.IsBooked = false;
          appointment.ClientId = 0;
          _db.Entry(appointment).State = EntityState.Modified;
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}