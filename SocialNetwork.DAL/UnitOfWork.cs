using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialContext _context;

        public UnitOfWork(SocialContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

