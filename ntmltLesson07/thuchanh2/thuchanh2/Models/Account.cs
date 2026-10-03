using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace thuchanh2.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Ho ve ten")]
        [Required(ErrorMessage ="Khong duoc de trong")]
        [MinLength(6, ErrorMessage ="it nhat 6 ki tu")]
        [MaxLength(20, ErrorMessage ="toi da 20 ki tu")]
        public string Fullname { get; set; }
        [Display(Name ="dia chi email")]
        [Required(ErrorMessage ="ko duoc de trong")]
        [EmailAddress(ErrorMessage ="ko dung dinh dang")]
        public string Email { get; set; }
        [Display(Name ="so dien thoai")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="ko duoc de trong")]
        //[RegularExpression(@"^(03|05|07|08|09)\d{8}$",ErrorMessage ="ko dung dinh dang")]

        [Remote(action:"XacthucPhone", controller:"Account")]
        public string Phone { get; set; }
        [Display(Name ="dia chi thuong tru")]
        [Required(ErrorMessage ="ko duoc de trong")]
        [StringLength(35,ErrorMessage ="ko vuot qua 35 ki tu")]
        public string Address { get; set; }
        [Display(Name ="anh dai dien")]
        public string Avatar { get; set; }
        [Display(Name = "ngay sinh")]
        [Required(ErrorMessage = "ko duoc de trong")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name ="gioi tinh")]
        public string Gender { get; set; }
        
        [Display(Name ="mat khau")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="link facebook ca nhan")]
        [Required(ErrorMessage = "ko duoc de trong")]
        [Url(ErrorMessage ="ko dung dinh dang")]
        public string Facebook { get; set; }





    }
}
