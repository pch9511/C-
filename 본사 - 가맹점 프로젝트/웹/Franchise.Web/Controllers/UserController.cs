using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Franchise.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Franchise.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _repository;
        private IMailRepository _mailRepository;
        /*---------------------------------------------------------------------
        메서드명: UserController 

        기능 : 생성자 기능 (주입)

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public UserController(IUserRepository repository, IMailRepository mailRepository)
        {
            _repository = repository;
            _mailRepository = mailRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        /*---------------------------------------------------------------------
        메서드명: Register : IACtionResult

        기능 : 회원기입 폼

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /*---------------------------------------------------------------------
        메서드명: Login : IACtionResult

        기능 : 로그인 폼

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        //로그인 폼
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /*---------------------------------------------------------------------
        메서드명: Login : async Task<IActionResult>

        기능 : 로그인 처리 기능

        만든날짜: 2023-03-07

        수정날짜 : 2023-03-09
        기타사항 : 유효성 검사 구분을 위해 수동검사로 변환
        연관함수 : X
        -----------------------------------------------------------------------*/
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(
            UserViewModel model, string returnUrl = null)
        {
            //if(ModelState.IsValid) 2023-03-09 수정사항
            //{
            //체크가 True냐 False냐로 로그인 할곳을 구분해야함
            if (!string.IsNullOrEmpty(model.Id) && !string.IsNullOrEmpty(model.Password))
            {
                if (model.Id == "Admin" && model.Password == "123456")
                {
                    var claims = new List<Claim>()
                        {
                            new Claim("Id", "Admin"),
                            new Claim("Name", model.Id),
                            new Claim("RegiNum", "Admin")
                        };

                    var ci = new ClaimsIdentity(claims, model.Password);

                    await HttpContext.Authentication.SignInAsync(
                         "Cookies", new ClaimsPrincipal(ci));

                    //_repository.MailNotice(model.Id);
                    _repository.Log(model.Id, "현재로그인");
                    return LocalRedirect("/Home/Index");
                }
                else if (_repository.IsCorrectUser(model.Id, model.Password))
                {
                    model.Check = _repository.IsCheck(model.Id);
                    if (!model.Check)
                    { 
                        var claims = new List<Claim>()
                        {
                            new Claim("Id", model.Check.ToString()),
                            new Claim("Name", model.Id),
                            new Claim("RegiNum", _repository.GetRegiNum(model.Id))
                            //기본 역할 필요?
                            //new Claim(ClaimTypes.Role, "Users"),
                        };

                        var ci = new ClaimsIdentity(claims, model.Password);

                        await HttpContext.Authentication.SignInAsync(
                            "Cookies", new ClaimsPrincipal(ci));
                        
                        //_repository.MailNotice(model.Id);
                        _repository.Log(model.Id, "현재로그인");
                        return LocalRedirect("/Home/Index");
                    }
                    else
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim("Id", model.Check.ToString()),
                            new Claim("Name", model.Id),
                            new Claim("RegiNum", _repository.GetRegiNum(model.Id))
                            //기본 역할 필요?
                            //new Claim(ClaimTypes.Role, "Users"),
                        };

                        var ci = new ClaimsIdentity(claims, model.Password);

                        await HttpContext.Authentication.SignInAsync(
                            "Cookies", new ClaimsPrincipal(ci));

                        _repository.Log(model.Id, "현재로그인");
                        return LocalRedirect("/Home/Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "아이디와 비밀번호가 일치하지 않습니다.");
                    return View();
                }
                //}
            }
            else
            {
                ModelState.AddModelError("", "아이디 혹은 비밀번호를 입력하세요.");
                return View();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: Register : IACtionResult

        기능 : 회원요청 처리 기능

        만든날짜: 2023-03-07

        수정날짜 : 2023-03-09
        기타사항 : 일부 유효성 검사를 수동 검사로 변환
        연관함수 : X
        -----------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Register(UserViewModel model)
        {
            if(!string.IsNullOrEmpty(model.RegiNum))
            {
                if(_repository.GetUserByRegiNum(model.RegiNum).Check)
                {
                    ModelState.AddModelError("", "이미 가입된 가맹점입니다.");
                    return View(model);
                }
                else if(string.IsNullOrEmpty(_repository.GetUserByRegiNum(model.RegiNum).RegiNum))
                {   //2023-03-09 수정사항
                    ModelState.AddModelError("", "해당 사업자등록번호는 없습니다.");
                    return View();
                }
            }
            if(string.IsNullOrEmpty(model.Id) || string.IsNullOrEmpty(model.Password)
                || string.IsNullOrEmpty(model.RegiNum)) //2023-03-09 수정사항
            {
                ModelState.AddModelError("", "잘못된 가입 시도입니다.");
                return View(model);
            }
            else
            {
                _repository.Register(model.Id, model.Password, model.RegiNum);
                return RedirectToAction("Index");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: Logout : async Task<IActionResult>

        기능 : 로그아웃 처리 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public async Task<IActionResult> Logout(string id)
        {
            // Cookies 사용
            _repository.Log(id, "로그아웃");
            await HttpContext.Authentication.SignOutAsync("Cookies");
            
            return Redirect("/User/Index");
        }

        public async Task<IActionResult> MailOk(int num, string id)
        {
            _repository.Regist(id);
            _mailRepository.DeleteMail(num);

            await HttpContext.Authentication.SignOutAsync("Cookies");

            return Redirect("/User/Index");
        }

        /*---------------------------------------------------------------------
        메서드명: Forbidden : IACtionResult

        기능 : 일단 예비용 삭제가능성있음

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*public IActionResult Forbidden()
        {
            return View();
        }*/

        /*---------------------------------------------------------------------
        메서드명: UserInfor : IACtionResult

        기능 : 정보 띄우는 기능 예비용

        만든날짜: 2023-03-06

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*[Authorize]
        public IActionResult UserInfor()
        {
            return View();
        }*/
    }
}
