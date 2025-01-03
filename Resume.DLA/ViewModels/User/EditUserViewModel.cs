using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.ViewModels.User
{
	public class EditUserViewModel
	{
		public int Id { get; set; }
		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(150, ErrorMessage = "طول بیشتر از حد مجاز است")]
		public string Email { get; set; }
		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string FirstName { get; set; }
		[Display(Name = "نام خانوادگی")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string LastName { get; set; }
		[Display(Name = "موبایل")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(11, ErrorMessage = "طول بیشتر از حد مجاز است")]
		public string Mobile { get; set; }
		[Display(Name = "رمز عبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public bool IsActive { get; set; }
	}
	public enum EditUserResult
	{
		Success,
		Error,
		DuplicateMobile,
		DuplicateEmail,
		NotFound
	}
}
