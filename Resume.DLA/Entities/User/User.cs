﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Entities.User
{
	public class User
	{
        [Key]
		public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
		public string RePassword { get; set; }
		public bool IsActive { get; set; }
        public DateTime RegDate { get; set; }
    }
}
