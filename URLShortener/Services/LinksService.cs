using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortener.Services
{
    public class LinksService : ILinksService
    {
        private Guid _guid;

        public LinksService()
        {
            _guid = new Guid();
        }

        public string GenerateRandomLink()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}
