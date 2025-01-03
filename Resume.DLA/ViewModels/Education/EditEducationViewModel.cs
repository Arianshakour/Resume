using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.ViewModels.Education
{
    public class EditEducationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string Title { get; set; }
        [Display(Name = "از تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateOnly Start { get; set; }
        [Display(Name = "تا تاریخ")]
        public DateOnly? End { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string Description { get; set; }
    }
    public enum EditEducationResult
    {
        Success,
        NotFound,
        Error
    }
}
