using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace MVC04.Models
{
    [Table("tblMembers")]
    public class Member
    {
        [Key]
        [Required]
        [MaxLength(255)]
        [Column("MemberID")] // Ánh xạ cột
        public string? MemberID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("FullName")] // Ánh xạ cột
        public string? Fullname { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        [Column("Email")] // Ánh xạ cột
        public string? Email { get; set; }

        [Required]
        [Column("PasswordHash")] // Ánh xạ cột
        public string? PasswordHash { get; set; } // Mật khẩu đã mã hóa

        [Required]
        [Column("CreateAt")] // Ánh xạ cột
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual ICollection<Nhanxet>? NhanXets { get; set; }
        
    }
}
