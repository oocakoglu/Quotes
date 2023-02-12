using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core.Models
{
    public class Author
    {
        public Author()
        {
            Quotes = new HashSet<Quote>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? CreatedAt { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
