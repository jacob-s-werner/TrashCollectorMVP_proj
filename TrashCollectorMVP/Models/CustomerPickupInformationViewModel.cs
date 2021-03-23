using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorMVP.Models
{
    public class CustomerPickupInformationViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<TemporaryPickupSuspension> TemporaryPickupSuspensions { get; set; }
        public List<OneTimePickup> OneTimePickups { get; set; }
    }
}
