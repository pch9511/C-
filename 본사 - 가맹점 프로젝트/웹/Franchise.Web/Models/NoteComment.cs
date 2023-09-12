using System;
using System.ComponentModel.DataAnnotations;

namespace Franchise.Web.Models
{

    public class NoteComment
    {
        public int Id { get; set; }
        public string BoardName { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "의견을 입력하세요.")]
        public string Opinion { get; set; }
        public DateTime PostDate { get; set; }
    }
}
