using cgi_tollgate_assignment_book_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.Services
{
    public interface IBookService
    {
        Book AddBook(Book book);
        Book GetBookById(int id);
        List<Book> GetBooks();
        bool UpdateBook(int id, Book book);
        bool DeleteBook(int id);
    }
}
