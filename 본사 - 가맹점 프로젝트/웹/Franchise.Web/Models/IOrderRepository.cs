using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Franchise.Web.Models
{
    public interface IOrderRepository
    {
        List<Order> GetAll(string RegiNum);
    }
}
