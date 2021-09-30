using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortener.Domain.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string GenuineURL { get; set; }
        public string ShortenedURL { get; set; }
    }
}
