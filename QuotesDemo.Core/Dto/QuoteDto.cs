using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core.Dto
{
    public class QuoteDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; } = null!;

        //public Quote ToQuote()
        //{
        //    return new Quote { Id = Id, AuthorId = AuthorId, Text = Text };
        //}

    }
}
