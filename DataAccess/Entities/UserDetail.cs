﻿using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace DataAccess.Entities
{
    public class UserDetail
    {
        [Key]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        public Gender Gender { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
