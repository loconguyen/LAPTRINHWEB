using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Learner
    {
        public Learner()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int LearnerID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        [Display(Name = "Tên")]
        public string FirstMidName { get; set; } = "";
        [Required(ErrorMessage = "Vui lòng nhập họ.")]
        [Display(Name = "Họ")]
        public string LastName { get; set; } = "";
        [DataType(DataType.Date)]
        [Display(Name = "Ngày nhập học")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/9999", ErrorMessage = "Ngày nhập học không hợp lệ.")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Ngành học")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn ngành học.")]
        public int MajorID { get; set; }

        public virtual Major? Major { get; set; }

        public virtual ICollection<Enrollment> Enrollments
        { get; set; }

    }
}
