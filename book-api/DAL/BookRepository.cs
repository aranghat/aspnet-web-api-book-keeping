using cgi_tollgate_assignment_book_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.DAL
{
    public class BookRepository : IBookRepository
    {
        /*
       Use constructor Injection to inject all required dependencies.
       */
        private readonly BookDataContext db;
        public BookRepository(BookDataContext _db)
        {
            
        }
        /*
      * This method should be used to save a new book.
      */
        public Book AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        /*
       * This method should be used to delete an existing book.
       */
        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        /*
       * This method should be used to get a book base on specified bookId.
       */
        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        /*
       * This method should be used to retreive all books.
       */
        public List<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        /*
       * This method should be used to update an existing book based on specified bookId.
       */
        public bool UpdateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
