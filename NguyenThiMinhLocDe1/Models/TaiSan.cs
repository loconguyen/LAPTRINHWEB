using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenThiMinhLocDe1.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    [Required]
    public string TenTs { get; set; } = null!;
    [Range(1,2000)]
    public decimal? NguyenGia { get; set; }
    [RegularExpression(@"(?!)^.+( .jpg | .jpeg | .png | .webp)$")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan MaLoaiNavigation { get; set; } = null!;
}
