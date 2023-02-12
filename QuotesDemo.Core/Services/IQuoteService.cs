using QuotesDemo.Core.Dto;
using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core.Services
{
    public interface IQuoteService
    {
        Task AddQuote(QuoteDto quoteDto);

        Task UpdateQuote(QuoteDto quoteDto);

        Task DeleteQuote(int quoteId);

        Task<IEnumerable<Quote>> ListQuotesWithAuthor(int? authorId);

        Task<IEnumerable<Quote>> ListQuotes();

        Task<Quote?> GetQuoteById(int quoteId);

        Task<Quote> GetRandomQuote();
    }
}
