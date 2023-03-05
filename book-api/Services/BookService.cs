using cgi_tollgate_assignment_book_api.DAL;
using cgi_tollgate_assignment_book_api.Exceptions;
using cgi_tollgate_assignment_book_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgi_tollgate_assignment_book_api.Services
{
    public class BookService : IBookService
    {
        /*
        Use constructor Injection to inject all required dependencies.
        */
        private readonly IBookRepository repo;
        public BookService(IBookRepository _repo)
        {
            
        }

        /*
	    * This method should be used to save a new book.
	    */
        public Book AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        /* This method should be used to delete an existing book.
         * Throw BookNotFoundException in case book not found based on specified bookId. 
         */
        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        /* This method should be used to get a book by bookId. 
         * Throw BookNotFoundException in case book not found based on specified bookId.
         */
        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        /* This method should be used to get a book all books. */
        public List<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        /* This method should be used to update a book by bookId.
         * Throw BookNotFoundException in case book not found based on specified bookId. 
         */
        public bool UpdateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
