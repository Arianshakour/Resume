using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Entities.AboutMe
{
    public class AboutMe
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Location { get; set; }
        public string? Bio { get; set; }
        public DateOnly? BrithDay { get; set; }
    }
}
