﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorMVP.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public double? TotalBill { get; set; }
        public DateTime? LastPickup { get; set; }

        [ForeignKey("WeeklyPickupDay")]
        public int WeeklyPickUpDayId { get; set; }
        public WeeklyPickupDay WeeklyPickUpDay { get; set; }
        
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [NotMapped]
        public double Longitude { get; set; }
        
        [NotMapped]
        public double Latitude { get; set; }
    }
}
