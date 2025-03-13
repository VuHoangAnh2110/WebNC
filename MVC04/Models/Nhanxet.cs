using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace MVC04.Models
{
    public class Nhanxet
    {
        [Key]
        public int PK_iNhanxetID { get; set; }

        [Required]
        public string sNoidung { get; set; }

        [Required]
        public DateTime tThoigianGhinhan { get; set; } = DateTime.Now;

        [Required]
        public int FK_iProductID { get; set; }

        [Required]
        public string FK_MemberName { get; set; }

        // Khóa ngoại
        [ForeignKey("FK_iProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("FK_MemberName")]
        public virtual Member Member { get; set; }
    }
}
