using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities.Common.Utilites.Results
{
    public interface IResult
    {
        bool IsSuccess { get;}
        string Message { get;}
    }
}
