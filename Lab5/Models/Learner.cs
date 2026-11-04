using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Lab5.Models;
public partial class Learner
{
    public int LearnerId { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập tên."), StringLength(100), Display(Name = "Tên và tên đệm")]
    public string FirstMidName { get; set; } = null!;
    [Required(ErrorMessage = "Vui lòng nhập họ."), StringLength(100), Display(Name = "Họ")]
    public string LastName { get; set; } = null!;
    [DataType(DataType.Date), Display(Name = "Ngày nhập học"), Range(typeof(DateTime), "1/1/1753", "12/31/9999", ErrorMessage = "Ngày nhập học không hợp lệ.")]
    public DateTime EnrollmentDate { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn chuyên ngành."), Display(Name = "Chuyên ngành")]
    public int MajorId { get; set; }
    [ValidateNever]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    [ValidateNever]
    public virtual Major Major { get; set; } = null!;
}
