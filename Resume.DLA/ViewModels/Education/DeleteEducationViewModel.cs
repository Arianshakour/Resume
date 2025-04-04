﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.ViewModels.Education
{
    public class DeleteEducationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string Title { get; set; }
    }
    public enum DeleteEducationResult
    {
        Success,
        Error
    }
}
