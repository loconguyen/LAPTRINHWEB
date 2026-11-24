using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab14.Models;

public partial class Sach
{
    [Key]
    public int MaSach { get; set; }

    public int MaTl { get; set; }

    public string TenSach { get; set; } = null!;

    [Range(50,1000)]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^.+\.(jpg|jpeg|png|webp)")]
    public string? Anh { get; set; }

    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
