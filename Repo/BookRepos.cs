using BookAPI.Data;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repo
{
    public class BookRepos : IBookRepos
    {
        private readonly BookContext context;

        public BookRepos(BookContext context)
        {
            this.context = context;
        }

        public async Task<List<BookModel>> GetAllBookAsync()
        {
            var records = await context.books.Select(x => new BookModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();

            return records;
        }

        public async Task<BookModel> GetBookByIdAsync(int BookId)
        {
            var records = await context.books.Where(x => x.Id == BookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).FirstOrDefaultAsync();

            return records;
        }

        public async Task<Books> AddBookAsync(BookModel Book)
        {
            var book = new Books()
            {
                Name = Book.Name,
                Description = Book.Description
            };
            context.books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBookAsync(int BookId, BookModel Book)
        {
            var book = await context.books.FindAsync(BookId);
            if(book != null)
            {
                book.Name = Book.Name;
                book.Description = Book.Description;
                await context.SaveChangesAsync();
            }
            
        }
        public async Task DeleteBookAsync(int BookId)
        {
            var book = new Books() { Id = BookId };
            context.books.Remove(book);
            await context.SaveChangesAsync();

        }
    }

}
