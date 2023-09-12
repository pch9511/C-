using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Franchise.Web.Models
{
    public class UserViewModel
    {
        [Display(Name = "아이디")]
        [Required(ErrorMessage = "아이디를 입력하시오.")]
        [StringLength(25, MinimumLength = 3,
        ErrorMessage = "아이디는 3자 이상 25자 이하로 입력하시오.")]
        public string Id { get; set; }

        [Display(Name = "비밀번호")]
        [Required(ErrorMessage = "비밀번호를 입력하시오.")]
        [StringLength(20, MinimumLength = 6,
        ErrorMessage = "비밀번호는 6자 이상 20자 이하로 입력하시오.")]
        public string Password { get; set; }

        public string RegiNum { get; set; } // 사업자번호 및 임시 로그인 아이디

        public bool Check { get; set; } // 임시로그인 구분
    }
}
