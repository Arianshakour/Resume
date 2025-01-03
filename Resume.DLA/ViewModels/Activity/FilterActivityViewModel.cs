using Resume.DLA.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.ViewModels.Activity
{
	public class FilterActivityViewModel : BasePaging<DetailsActivityViewModel>
	{
		[Display(Name = "عنوان")]
		public string Title { get; set; }
    }
}
