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
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Adress { get; set; }
    }
}
