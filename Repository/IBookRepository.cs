using System;
using BookStore_V2.Models;

namespace BookStore_V2.Repository
{
    public interface IBookRepository
    {
        Task<List<BookDetailsDto>> GetAllBooks();
        Task<BookDetailsDto> GetBookDetailsById(int id);
        Task<int> CreateBook(CreateBookDto model);
        Task<bool> UpdateBook(int id, UpdateBookDto model);
        Task<bool> RemoveBook(int id);

    }
}
