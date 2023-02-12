using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; } = "";
        public byte[]? CreatedAt { get; set; } = null!;

        public virtual Author Author { get; set; } = null!;
    }
}
