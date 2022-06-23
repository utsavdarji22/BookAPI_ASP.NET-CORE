using BookAPI.Data;
using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repo
{
    public interface IBookRepos
    {
        Task<List<BookModel>> GetAllBookAsync();
        Task<BookModel> GetBookByIdAsync(int BookId);
        Task<Books> AddBookAsync(BookModel Book);
        Task UpdateBookAsync(int BookId, BookModel Book);
        Task DeleteBookAsync(int BookId);
    }
}
