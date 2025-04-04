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
				Password = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70",
				RePassword = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70"
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
