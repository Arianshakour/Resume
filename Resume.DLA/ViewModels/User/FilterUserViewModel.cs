using Resume.DLA.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.ViewModels.User
{
	public class FilterUserViewModel : BasePaging<UserDetailsViewModel>
	{
		[Display(Name = "ایمیل")]
		public string? Email { get; set; }
		[Display(Name = "موبایل")]
		public string? Mobile { get; set; }
	}
}
