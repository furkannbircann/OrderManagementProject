using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int CompanyId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal? Price { get; set; }
        public Company Company { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
