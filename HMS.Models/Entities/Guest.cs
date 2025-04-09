using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.Entities
{
    public class Guest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
      
        public string Surname { get; set; } = null!;

        public int IdentityNumber { get; set; }

        public string MobileNumber { get; set; } = null!;

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
