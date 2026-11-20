using System.ComponentModel.DataAnnotations;

namespace DeThi.Models
{
    public class HangHoaViewModel
    {
        public int MaLoai { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHang { get; set; } = null!;

        [Range(typeof(decimal), "100", "5000", ErrorMessage = "Giá phải từ 100 đến 5000.")]
        public decimal? Gia { get; set; }

        [StringLength(100)]
        [RegularExpression(@".+\.(?:[Jj][Pp][Gg]|[Pp][Nn][Gg]|[Gg][Ii][Ff]|[Tt][Ii][Ff][Ff])", ErrorMessage = "Ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff.")]
        public string? Anh { get; set; }
    }
}
