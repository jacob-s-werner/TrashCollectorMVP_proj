﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorMVP.Models
{
    public class EmployeeCustomerViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
