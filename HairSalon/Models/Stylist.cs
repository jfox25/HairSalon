using System.Collections.Generic;
using System;

namespace HairSalon.Models
{
    public class Stylist
    {
        public Stylist()
        {
            this.Clients = new HashSet<Client>();
            this.Appointments = new HashSet<Appointment>();
        }

        public int StylistId { get; set; }
        public string Name { get; set; }
        public int YearsOfExperiance { get; set; }
        public DateTime StartDate { get; set; }
        public int TotalRevenue { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public void UpdateTotalRevenue()
        {
          TotalRevenue += 60;
        }

        public void GenerateAppoinments()
        {
            List<string> times = new List<string>(){"8am-9am", "9am-10am", "10am-11am", "12am-1pm", "2pm-3pm"};
            foreach (string time in times)
            {
                Appointment appointment = new Appointment();
                appointment.Time = time;
                appointment.IsBooked = false;
                appointment.StylistId = StylistId;
                Appointments.Add(appointment);
            }
        }
    }
}