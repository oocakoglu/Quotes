using QuotesDemo.Core.Models;

namespace QuotesDemo.WebUI.Models
{
    public class QuoteVM
    {
        public QuoteVM()
        {
            Quotes = new HashSet<Quote>();
            Authors = new HashSet<Author>();     
        }

        public IEnumerable<Quote> Quotes { get; set; }

        public IEnumerable<Author> Authors { get; set; }

        public int? SelectedAuthor { get; set; }
    }
}
