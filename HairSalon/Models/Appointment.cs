using System.Collections.Generic;

namespace HairSalon.Models
{
    public class Appointment
    {
      public int AppointmentId { get; set; }
      public int StylistId { get; set; }
      public int ClientId { get; set; }
      public string Time { get; set; }
      public bool IsBooked { get; set; }
      public virtual Stylist Stylist { get; set;} 
      public virtual Client Client { get; set;} 
    }
}