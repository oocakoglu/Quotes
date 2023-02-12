using QuotesDemo.Core;
using QuotesDemo.Core.Dto;
using QuotesDemo.Core.Extensions;
using QuotesDemo.Core.Models;
using QuotesDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Service.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuoteService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddQuote(QuoteDto quoteDto)
        {
            Quote quote = quoteDto.ToQuote();
            quote.CreatedAt = BitConverter.GetBytes(DateTime.Now.Ticks);
            await _unitOfWork.Quotes.AddAsync(quote);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteQuote(int quoteId)
        {
            Quote? quote = await _unitOfWork.Quotes.GetByIdAsync(quoteId);
            if (quote != null)
            {
                _unitOfWork.Quotes.Remove(quote);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<Quote?> GetQuoteById(int quoteId)
        {
            return await _unitOfWork.Quotes.GetByIdAsync(quoteId);
        }

        public async Task<Quote> GetRandomQuote()
        {
            return await _unitOfWork.Quotes.GetRandomQuote();
        }

        public async Task<IEnumerable<Quote>> ListQuotes()
        {
            return await _unitOfWork.Quotes.GetAllAsync();
        }

        public async Task<IEnumerable<Quote>> ListQuotesWithAuthor(int? authorId)
        {
            return await _unitOfWork.Quotes.ListQuotesWithAuthor(authorId);
        }

        public async Task UpdateQuote(QuoteDto quoteDto)
        {
            Quote? upQuote = await _unitOfWork.Quotes.GetByIdAsync(quoteDto.Id);
            if (upQuote != null)
            {
                upQuote.Text = quoteDto.Text;
                upQuote.AuthorId = quoteDto.AuthorId;
                await _unitOfWork.CommitAsync();
            }
        }


    }
}
