using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Franchise.Web.Models
{
    public class Mail
    {
        public int Num { get; set; }
        public string RegiNum { get; set; }
        [Display(Name = "아이디")]
        public string Id { get; set; }
        [Display(Name = "제목")]
        public string Title { get; set; }
        [Display(Name = "내용")]
        public string Content { get; set; }
        [Display(Name = "작성일")]
        public DateTime Date { get; set; }

    }
}
