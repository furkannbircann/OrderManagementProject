using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities.Common;

namespace OrderManagement.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string OrdererName { get; set; }
        public DateTime OrderDate { get; set; }
        public Company Company { get; set; }
        public Product Product { get; set; }
    }
}
