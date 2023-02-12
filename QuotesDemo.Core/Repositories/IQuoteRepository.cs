using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core.Repositories
{
    public interface IQuoteRepository : IRepository<Quote>
    {
        Task<IEnumerable<Quote>> ListQuotesWithAuthor(int? authorId);

        Task<Quote> GetRandomQuote();
    }
}
