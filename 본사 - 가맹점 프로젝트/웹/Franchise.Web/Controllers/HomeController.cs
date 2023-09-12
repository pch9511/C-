using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Franchise.Web.Models;

namespace Franchise.Web.Controllers
{
    public class HomeController : Controller
    {

        /*---------------------------------------------------------------------
        메서드명: Index : IACtionResult

        기능 : TEST

        만든날짜: 2023-03-06

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public IActionResult Index()
        {

            var claims = HttpContext.User.Claims;

            return View();
        }

        public IActionResult Popup()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
