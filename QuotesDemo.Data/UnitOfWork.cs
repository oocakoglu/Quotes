using Microsoft.EntityFrameworkCore.Migrations;
using QuotesDemo.Core;
using QuotesDemo.Core.Repositories;
using QuotesDemo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuoteDbContext _context;
        private AuthorRepository? _authorRepository;
        private QuoteRepository? _quoteRepository;
        private UserRepository? _userRepository;

        public UnitOfWork(QuoteDbContext context)
        {
            this._context = context;
        }


        public IAuthorRepository Authors => _authorRepository = _authorRepository ?? new AuthorRepository(_context);

        public IQuoteRepository Quotes => _quoteRepository = _quoteRepository ?? new QuoteRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
