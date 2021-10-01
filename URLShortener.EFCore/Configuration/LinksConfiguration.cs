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
    public class LinksConfiguration : IEntityTypeConfiguration<Link>
    {
        
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.HasData(
               new Link
               {
                   Id = 1,
                   GenuineURL = "https://www.youtube.com/watch?v=3QbaTfN0-8s",
                   ShortenedURL = "short/url/1"
               },
               new Link
               {
                   Id = 2,
                   GenuineURL = "https://www.youtube.com/watch?v=bHwl8TdEI6k",
                   ShortenedURL = "short/url/2"
               },
               new Link
               {
                   Id = 3,
                   GenuineURL = "https://www.youtube.com/watch?v=_2By2ane2I4&t=867s",
                   ShortenedURL = "short/url/3"
               }
            );
        }
    }
}
