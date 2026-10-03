using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ntmltLesson07.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("ten dang nhap")]
        [Required(ErrorMessage =" ten dang nhap ko dc trong")]
        [StringLength(20,MinimumLength = 3,ErrorMessage =" do dai ki tu 3-20")]
        public string UserName { get; set; }
        [DisplayName("Ho va ten")]
        [Required(ErrorMessage ="Ho va ten ko duoc de trong")]
        public string FullName { get; set; }
        [DisplayName("Mat khau")]
        [Required(ErrorMessage = "Mat khau ko duoc de trong")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("go lai Mat khau")]
        [Required(ErrorMessage = "Mat khau ko dung")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
        [DisplayName("hom thu")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="email ko duoc bo trong")]

        public string Email { get;set; }

        [DisplayName("Điện thoại")]
        [RegularExpression(@"0\d{9,12}$", ErrorMessage = "Phải bắt đầu bằng 0 và dài 10-12 số")]
        public string Phone { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime Birthday { get; set; }

    }
}
