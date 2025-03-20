using System.ComponentModel.DataAnnotations;

namespace MVC04.Models
{
    public class DangKyViewModel
    {
        [Required(ErrorMessage = "Họ tên không được để trống.")]
        public string? Fullname { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
        [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không khớp.")]
        public string? ConfirmPassword { get; set; }
    }
}
