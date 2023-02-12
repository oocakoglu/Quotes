using QuotesDemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IQuoteRepository Quotes { get; }
        IUserRepository Users { get; }

        Task<int> CommitAsync();
    }
}
