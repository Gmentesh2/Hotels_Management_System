using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HMS.Models.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsFree { get; set; }

        public decimal Price { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; } = null!;
    }
}
