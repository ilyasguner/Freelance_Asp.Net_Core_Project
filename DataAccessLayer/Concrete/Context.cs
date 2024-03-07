using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context:IdentityDbContext<Employers,EmployersRole,int>
	{
		//migration ile veri tabanının oluşturulması
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-U7QTN9J;database=SınamaDB;integrated security=true;");
		}

		//veri tabanı tablolarımız
		public DbSet<Job> Jobs { get; set; }

		public DbSet<Offer> Offers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Platform> Platforms { get; set; }
    }
}
