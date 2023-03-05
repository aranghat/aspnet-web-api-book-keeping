using cgi_tollgate_assignment_book_api.DAL;
using cgi_tollgate_assignment_book_api.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace test.Repository
{
    [Collection("Database collection")]
    [TestCaseOrderer("test.PriorityOrderer", "test")]
    public class BookRepositoryTest
    {
        BookRepository repository;
        public BookRepositoryTest(DatabaseFixture databaseFixture)
        {
            repository = new BookRepository(databaseFixture.context);
        }

        [Fact, TestPriority(1)]
        public void GetAllBooksShouldReturnList()
        {
            var actual = repository.GetBooks();
            Assert.IsAssignableFrom<IEnumerable<Book>>(actual);
            Assert.NotNull(actual);
        }

        [Fact, TestPriority(2)]
        public void GetBookByIdShouldReturnBook()
        {
            int bookId = 1;

            var actual = repository.GetBookById(bookId);
            Assert.IsAssignableFrom<Book>(actual);
            Assert.NotNull(actual);
        }

        [Fact, TestPriority(3)]
        public void UpdateBookShouldSuccess()
        {
            Book book = repository.GetBookById(1);
            book.Price = 800;

            var actual = repository.UpdateBook(1, book);
            Assert.True(actual);
        }

        [Fact, TestPriority(4)]
        public void AddBookShouldSuccess()
        {
            Book book = new Book { BookName = "The Secret", AuthorName = "Rhonda Byrne", Genre = "Spiritual", Price = 545 };
            var actual = repository.AddBook(book);

            Assert.IsAssignableFrom<Book>(actual);
            Assert.Equal(2, actual.BookId);
        }

        [Fact, TestPriority(5)]
        public void DeleteBookShouldSuccess()
        {
            int bookId = 2;

            var actual = repository.DeleteBook(bookId);
            Assert.True(actual);
            Assert.Null(repository.GetBookById(bookId));
        }
    }
}
