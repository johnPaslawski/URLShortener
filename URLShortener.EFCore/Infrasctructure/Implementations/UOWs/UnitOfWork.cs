using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Models;
using URLShortener.EFCore.EFData;
using URLShortener.EFCore.Infrasctructure.Implementations.Repositories;
using URLShortener.EFCore.Infrasctructure.Repositories;
using URLShortener.EFCore.Infrasctructure.UOWs;

namespace URLShortener.EFCore.Infrasctructure.Implementations.UOWs
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly URLShortenerDbContext _context;

        public UnitOfWork(URLShortenerDbContext context)
        {
            this._context = context;
        }

        public IGenericRepository<Link> Links => new GenericRepository<Link>(_context);
        public IGenericRepository<Report> Reports => new GenericRepository<Report>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}
