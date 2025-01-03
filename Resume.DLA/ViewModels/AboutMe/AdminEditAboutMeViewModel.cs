using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.ViewModels.AboutMe
{
    public class AdminEditAboutMeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(60, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? LastName { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? Mobile { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        [EmailAddress(ErrorMessage = "لطفا فرمت ایمیل معتبر وارد کنید")]
        public string? Email { get; set; }
        [Display(Name = "سمت شغلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? Position { get; set; }
        [Display(Name = "ادرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? Location { get; set; }
        [Display(Name = "بیوگرافی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? Bio { get; set; }
        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateOnly? BrithDay { get; set; }
    }
    public enum AdminEditAboutMeResult
    {
        Success,
        Error,
        NotFound
    }
}
