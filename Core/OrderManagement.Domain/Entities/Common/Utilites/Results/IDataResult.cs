using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities.Common.Utilites.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
