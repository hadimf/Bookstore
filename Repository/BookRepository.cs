using System;
using BookStore_V2.Data;
using BookStore_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore_V2.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookDetailsDto>> GetAllBooks()
        {
            var books = await _context.Books.Select(x => new BookDetailsDto()
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
                Amount = x.Amount
            }).ToListAsync();
            return books;
        }

        public async Task<BookDetailsDto> GetBookDetailsById(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id)
                                        .Select(x => new BookDetailsDto()
                                        {
                                            Id = x.Id,
                                            Title = x.Title,
                                            Description = x.Description,
                                            Amount = x.Amount
                                        }).FirstOrDefaultAsync();
            return book;
        }

        public async Task<int> CreateBook(CreateBookDto model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                Amount = model.Amount
            };
            _context.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<bool> UpdateBook(int id, UpdateBookDto model)
        {
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book != null)
            {
                book.Title = model.Title;
                book.Description = model.Description;
                book.Amount = model.Amount;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveBook(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book != null)
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
