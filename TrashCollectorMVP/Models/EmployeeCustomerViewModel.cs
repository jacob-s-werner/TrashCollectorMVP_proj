using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorMVP.Models
{
    public class EmployeeCustomerViewModel
    {
        public List<Employee> Employees { get; set; }
        public int? WeeklyPickupDayId { get; set; }

        [NotMapped]
        public CustomerPickupInformationViewModel customerPickupInformationViewModel { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
