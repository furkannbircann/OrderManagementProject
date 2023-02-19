using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Features.Commands.Company.CreateCompany
{
    public class CreateCompanyCommandRequest : IRequest<CreateCompanyCommandResponse>
    {
        public string CompanyName { get; set; }
        public bool IsApproved { get; set; }
        public DateTime OrderStartTime { get; set; }
        public DateTime OrderFinishTime { get; set; }
    }
}
