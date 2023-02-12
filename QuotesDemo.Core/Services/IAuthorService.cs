using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuotesDemo.Core.Services
{
    public interface IAuthorService
    {
        Task AddAuthor(Author author);

        Task UpdateAuthor(Author author);

        Task DeleteAuthor(int authorId);

        Task<IEnumerable<Author>> ListAuthors();

        Task<Author?> GetAuthorById(int authorId);


    }
}
