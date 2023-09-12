using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Franchise.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Franchise.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index(string id)
        {
            IEnumerable<Order> orders;

            orders = _repository.GetAll(id);
            return View(orders);
        }
    }
}
