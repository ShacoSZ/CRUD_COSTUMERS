using System;
using Microsoft.EntityFrameworkCore;
using App_asp_net_mvc.Models;

namespace App_asp_net_mvc.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
		) : base(options)
		{
		}

		public DbSet<Customers> customers { get; set; }
    }
}

