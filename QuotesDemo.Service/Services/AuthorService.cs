using QuotesDemo.Core;
using QuotesDemo.Core.Models;
using QuotesDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuotesDemo.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddAuthor(Author author)
        {
            author.CreatedAt = BitConverter.GetBytes(DateTime.Now.Ticks);
            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAuthor(int authorId)
        {
            Author? author = await _unitOfWork.Authors.GetByIdAsync(authorId);
            if (author != null)
            {
                _unitOfWork.Authors.Remove(author);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<Author?> GetAuthorById(int authorId)
        {
            return await _unitOfWork.Authors.GetByIdAsync(authorId);
        }

        public async Task<IEnumerable<Author>> ListAuthors()
        {
            return await _unitOfWork.Authors.GetAllAsync();
        }

        public async Task UpdateAuthor(Author author)
        {
            Author? upAuthor = await _unitOfWork.Authors.GetByIdAsync(author.Id);
            if (upAuthor != null)
            {
                upAuthor.Name = author.Name;
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
