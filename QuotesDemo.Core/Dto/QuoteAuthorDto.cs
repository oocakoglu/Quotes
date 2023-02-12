using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuotesDemo.Core.Dto
{
    public class QuoteAuthorDto
    {

        public bool Status { get; set; } = false;

        public string Text { get; set; } = null!;

        public string Author { get; set; } = null!;

        public static QuoteAuthorDto Success(string author, string text)
        {
            return new QuoteAuthorDto { Status = true, Author = author, Text = text };
        }

        public static QuoteAuthorDto Fail(string author, string text)
        {
            return new QuoteAuthorDto { Status = false, Author = author, Text = text };
        }
    }
}
