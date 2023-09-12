using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Franchise.Web.Models
{
    public class Order
    {
        public int Num { get; set; }
        public string Id { get; set; }
        [Display(Name = "가맹점번호")]
        public string RegiNum { get; set; }
        [Display(Name = "제품명")]
        public string Name { get; set; }
        [Display(Name = "가격")]
        public int Price { get; set; }
        [Display(Name = "수량")]
        public int Account { get; set; }
        [Display(Name = "현황")]
        public string State { get; set; }
        [Display(Name = "지불방식")]
        public string Pay { get; set; }
        [Display(Name = "날짜")]
        public DateTime Date { get; set; }
    }
}
