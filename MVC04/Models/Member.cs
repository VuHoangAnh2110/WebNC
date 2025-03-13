using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace MVC04.Models
{
    public class Member
    {
        [Key]
        [Required]
        [MaxLength(255)]
        public string MemberName { get; set; }

        [Required]
        public string Matkhau { get; set; }

        // Navigation property
        public virtual ICollection<Nhanxet> NhanXets { get; set; }
    }
}
