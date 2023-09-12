using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Franchise.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Franchise.Web.Controllers
{
    public class QnAController : Controller
    {
        private IQnARepository _repository;


        public QnAController(IQnARepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            IEnumerable<QnA> qnAs = _repository.GetAll();
            return View(qnAs);
        }

        public IActionResult QnADetail(string id)
        {

            QnA qna = _repository.GetDetail(id);

            return View(qna);
        }
    }
}
