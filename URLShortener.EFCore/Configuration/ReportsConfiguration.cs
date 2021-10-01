using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Models;

namespace URLShortener.EFCore.Configuration
{
    public class ReportsConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasData(
                new Report
                {
                    Id = 1, 
                    Author = "Test Mike", 
                    CreationTime = DateTime.Now, 
                    Description = "Important inner report on topic A",
                    Content = "This is test content for an important inner report on topic A. There is a place for report details and content."
                },
                new Report
                {
                    Id = 2,
                    Author = "Trial John",
                    CreationTime = DateTime.Now,
                    Description = "Important inner report on topic B",
                    Content = "This is test content for an important inner report on topic B. There is a place for report details and content."
                },
                new Report
                {
                    Id = 3,
                    Author = "Excercise Bob",
                    CreationTime = DateTime.Now,
                    Description = "Important inner report on topic C",
                    Content = "This is test content for an important inner report on topic C. There is a place for report details and content."
                }
            );
        }
    }
}
