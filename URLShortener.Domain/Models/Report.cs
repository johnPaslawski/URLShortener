using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace URLShortener.Domain.Models
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime CreationTime  { get; set; }
        public string Author  { get; set; }
        public string Description  { get; set; }
        public string Content  { get; set; }
    }
}
