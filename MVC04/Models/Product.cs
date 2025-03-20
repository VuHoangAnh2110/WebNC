using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace MVC04.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(255)]
        public string? ProductName { get; set; }

        [Required]
        [Url]
        [RegularExpression(@".*\.png$", ErrorMessage = "Image must be a PNG file.")]
        public string? ImageURL { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Product price must be >= 0.")]
        public decimal ProductPrice { get; set; }

        public string? Description { get; set; }

        // Navigation property
        public virtual ICollection<Nhanxet>? NhanXets { get; set; }
    }



}
