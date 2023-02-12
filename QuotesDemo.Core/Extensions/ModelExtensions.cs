using QuotesDemo.Core.Dto;
using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuotesDemo.Core.Extensions
{
    public static class ModelExtensions
    {
        public static Quote ToQuote(this QuoteDto quoteDto)
        {
            Quote quote = new Quote();
            quote.Id = quoteDto.Id;
            quote.AuthorId = quoteDto.AuthorId;
            quote.Text= quoteDto.Text;
            return quote;
        }


        public static QuoteDto ToQuoteDto(this Quote quote)
        {
            QuoteDto quoteDto = new QuoteDto();
            quoteDto.Id = quote.Id;
            quoteDto.AuthorId = quote.AuthorId;
            quoteDto.Text = quote.Text;
            return quoteDto;
        }



    }
}
