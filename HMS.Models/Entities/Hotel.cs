using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.Entities
{
    public class Hotel
    {   
        public int Id { get; set; }
      
        public string Name { get; set; } = null!;
      
        public int Rating { get; set; }

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public int ManagerId { get; set; }

        public Manager? Manager { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
