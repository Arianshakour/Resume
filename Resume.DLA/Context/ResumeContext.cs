using Microsoft.EntityFrameworkCore;
using Resume.DLA.Entities.AboutMe;
using Resume.DLA.Entities.Activity;
using Resume.DLA.Entities.ContactUs;
using Resume.DLA.Entities.Education;
using Resume.DLA.Entities.Job;
using Resume.DLA.Entities.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DLA.Context
{
	public class ResumeContext:DbContext
	{
		public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
		{


		}
		public DbSet<User> Users { get; set; }
		public DbSet<ContactUs> ContactUsTable { get; set; }
		public DbSet<AboutMe> AboutMeTable { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Education> Educations { get; set; }
		public DbSet<Job> Jobs { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(new User()
			{
				RegDate = new DateTime(2024, 12, 18),
				FirstName = "آریان",
				LastName = "شکور",
				Email = "B@yahoo.com",
				Id = 1,
				IsActive = true,
				Mobile = "09121112233",
				Password = "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B",
				RePassword = "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B"
			});
            modelBuilder.Entity<AboutMe>().HasData(new AboutMe()
            {
                BrithDay = DateOnly.FromDateTime(DateTime.Now),
				FirstName="",
				LastName = "",
				Mobile = "",
				Email = "",
				Bio = "",
				Id=1,
				Location = "",
				Position = ""
            });
            base.OnModelCreating(modelBuilder);
		}
	}
}
