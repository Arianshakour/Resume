using Resume.DLA.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.ViewModels.Job
{
	public class FilterJobViewModel : BasePaging<DetailJobViewModel>
	{
		[Display(Name = "عنوان")]
		public string? Title { get; set; }
		[Display(Name = "از تاریخ")]
		public DateOnly? Start { get; set; }
		[Display(Name = "تا تاریخ")]
		public DateOnly? End { get; set; }
	}
}
