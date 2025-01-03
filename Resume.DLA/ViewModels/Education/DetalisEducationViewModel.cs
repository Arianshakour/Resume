using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.ViewModels.Education
{
    public class DetalisEducationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly? End { get; set; }
        public string Description { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
