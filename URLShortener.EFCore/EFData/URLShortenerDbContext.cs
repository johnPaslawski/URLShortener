using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Models;
using URLShortener.EFCore.Configuration;

namespace URLShortener.EFCore.EFData
{
    public class URLShortenerDbContext : DbContext
    {
        

        public DbSet<Link> Links { get; set; }
        public DbSet<Report> Reports { get; set; }

        public URLShortenerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ReportsConfiguration());
            //modelBuilder.ApplyConfiguration(new LinksConfiguration());

        }
    }
}
