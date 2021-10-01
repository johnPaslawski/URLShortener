using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortener.DTO
{
    public class ReportDto
    {
        public DateTime CreationTime { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}
