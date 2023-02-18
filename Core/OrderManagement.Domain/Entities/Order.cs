using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string OrdererName { get; set; }
        public DateTime OrderDate { get; set; }
        public Company Company { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
