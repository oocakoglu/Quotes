using Microsoft.EntityFrameworkCore;
using QuotesDemo.Core.Models;
using QuotesDemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Data.Repositories
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        public QuoteRepository(QuoteDbContext context): base(context)    
        { 
        }
        private QuoteDbContext quoteDbContext
        {
            get { return (Context as QuoteDbContext)!; }
        }

        public async Task<Quote> GetRandomQuote()
        {
            return await quoteDbContext.Quotes.Include(a => a.Author).OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefaultAsync() ?? new Quote();
        }

        public async Task<IEnumerable<Quote>> ListQuotesWithAuthor(int? authorId)
        {
            IQueryable<Quote> data = quoteDbContext.Quotes;
            if (authorId != null)
            {
                data = data.Where(q => q.AuthorId == authorId);
            }

            return await data
                .Include(a => a.Author)
                .ToListAsync();
        }
    }
}
