using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorMVP.Models
{
    public class WeeklyPickupDay
    {
        [Key]
        public int Id { get; set; }
        public string Day { get; set; }
    }
}
