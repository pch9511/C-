using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Franchise.Web.Models
{
    public class QnA 
    {
        public string State { get; set; }       
        [Display(Name = "질문")]
        public string Question { get; set; }
        [Display(Name = "답변")]
        public string ChatLog { get; set; }
        [Display(Name = "작성일")]
        public DateTime Date { get; set; }

    }
}
