using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Models;
using URLShortener.EFCore.Infrasctructure.Repositories;

namespace URLShortener.EFCore.Infrasctructure.UOWs
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Link> Links { get; }
        IGenericRepository<Report> Reports { get; }
        Task Save();
    }
}
