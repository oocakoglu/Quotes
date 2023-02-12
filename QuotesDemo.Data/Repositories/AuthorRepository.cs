using QuotesDemo.Core.Models;
using QuotesDemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(QuoteDbContext context): base(context)            
        { 
        }

        private QuoteDbContext quoteDbContext
        {
            get { return (Context as QuoteDbContext)!; }
        }
    }
}
