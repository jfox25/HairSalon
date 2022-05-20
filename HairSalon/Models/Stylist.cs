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
    }
}