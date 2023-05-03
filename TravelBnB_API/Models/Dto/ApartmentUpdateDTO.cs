﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBnB_API.Models.Dto
{
    public class ApartmentUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string? Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int? Mq2 { get; set; }
        public int? Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }
        



    }
}
  