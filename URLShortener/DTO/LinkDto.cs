using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortener.DTO
{
    public class LinkDto
    {
        public string GenuineURL { get; set; }
        public string ShortenedURL { get; set; }
    }
}
