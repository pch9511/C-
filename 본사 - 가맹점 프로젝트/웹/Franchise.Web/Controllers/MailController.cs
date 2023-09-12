using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Franchise.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Franchise.Web.Controllers
{
    public class MailController : Controller
    {
        private IMailRepository _repository;

        public MailController(IMailRepository repository)
        {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index(string id)
        {
            IEnumerable<Mail> mails;

            mails = _repository.GetMail(id);

            return View(mails);
        }

        public IActionResult MailDetail(int id)
        {

            Mail mail = _repository.GetMailDetail(id);

            return View(mail);
        }
    }
}
