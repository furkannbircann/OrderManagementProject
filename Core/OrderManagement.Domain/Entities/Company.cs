using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public DateTime OrderStartTime { get; set; }
        public DateTime OrderFinishTime { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
