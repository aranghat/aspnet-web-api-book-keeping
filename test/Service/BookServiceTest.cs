using cgi_tollgate_assignment_book_api.DAL;
using cgi_tollgate_assignment_book_api.Exceptions;
using cgi_tollgate_assignment_book_api.Models;
using cgi_tollgate_assignment_book_api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace test.Service
{
    [TestCaseOrderer("test.PriorityOrderer", "test")]
    public class BookServiceTest
    {
        #region Positive Tests
        [Fact, TestPriority(1)]
        public void AddBookShouldReturnBook()
        {
            var mockRepo = new Mock<IBookRepository>();
            Book book = new Book { BookName = "Rich Dad Poor Dad", AuthorName = "Robert T Kiyosaki", Genre = "Personal Development", Price = 190 };
            mockRepo.Setup(repo => repo.AddBook(book)).Returns(book);
            var service = new BookService(mockRepo.Object);
            var actual = service.AddBook(book);
            Assert.IsAssignableFrom<Book>(actual);
        }
        [Fact, TestPriority(2)]
        public void GetBookByIdShouldReturnBook()
        {
            int bookId = 1;
            Book book = new Book { BookName = "Five Point Someone", AuthorName = "Chetan Bhagat", Genre = "Fiction", Price = 137 };
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetBookById(bookId)).Returns(book);
            var service = new BookService(mockRepo.Object);
            var actual = service.GetBookById(bookId);
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<Book>(actual);
            Assert.Equal("Chetan Bhagat", actual.AuthorName);
        }

        [Fact, TestPriority(3)]
        public void GetBooksShouldReturnListOfBooks()
        {
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetBooks()).Returns(this.GetBooks());
            var service = new BookService(mockRepo.Object);
            var actual = service.GetBooks();
            Assert.IsAssignableFrom<List<Book>>(actual);
        }

        [Fact, TestPriority(4)]
        public void UpdateBookShouldReturnTrue()
        {
            int Id = 1;
            Book book = new Book { BookName = "Think Like a Monk", AuthorName = "Jay Shetty", Genre = "Society & Culture", Price = 325 };
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetBookById(Id)).Returns(book);
            mockRepo.Setup(repo => repo.UpdateBook(Id, book)).Returns(true);
            var service = new BookService(mockRepo.Object);
            var actual = service.UpdateBook(Id, book);
            Assert.True(actual);
        }

        [Fact, TestPriority(5)]
        public void DeleteBookShouldReturnTrue()
        {
            var mockRepo = new Mock<IBookRepository>();
            var Id = 2;
            Book book = new Book { };
            mockRepo.Setup(repo => repo.GetBookById(Id)).Returns(book);
            mockRepo.Setup(repo => repo.DeleteBook(Id)).Returns(true);
            var service = new BookService(mockRepo.Object);
            var actual = service.DeleteBook(Id);
            Assert.True(actual);
        }

        private List<Book> GetBooks()
        {
            List<Book> books = new List<Book> {
               new Book {BookName="One Arranged Murder", AuthorName="Chetan Bhagat", Genre="Romance", Price=155 }
            };
            return books;
        }
        #endregion
        #region Negative Tests
        [Fact, TestPriority(6)]
        public void GetBookByIdShouldThrowException()
        {
            int id = 5;
            Book book = null;
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetBookById(id)).Returns(book);
            var service = new BookService(mockRepo.Object);
            var actual = Assert.Throws<BookNotFoundException>(() => service.GetBookById(id));
            Assert.Equal($"Book with id: {id} does not exists", actual.Message);
        }

        [Fact, TestPriority(7)]
        public void DeleteBookShouldThrowException()
        {
            var mockRepo = new Mock<IBookRepository>();
            var bookId = 5;
            Book book = null;
            mockRepo.Setup(repo => repo.GetBookById(bookId)).Returns(book);
            mockRepo.Setup(repo => repo.DeleteBook(bookId)).Returns(false);
            var service = new BookService(mockRepo.Object);
            var actual = Assert.Throws<BookNotFoundException>(() => service.DeleteBook(bookId));
            Assert.Equal($"Book with id: {bookId} does not exists", actual.Message);
        }

        [Fact, TestPriority(8)]
        public void UpdateBookShouldThrowException()
        {
            int bookId = 5;
            Book book = new Book { BookName = "Think Like a Monk", AuthorName = "Jay Shetty", Genre = "Society & Culture", Price = 325 };
            Book _book = null;
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetBookById(bookId)).Returns(_book);
            mockRepo.Setup(repo => repo.UpdateBook(bookId, book)).Returns(false);
            var service = new BookService(mockRepo.Object);
            var actual = Assert.Throws<BookNotFoundException>(() => service.UpdateBook(bookId, book));
            Assert.Equal($"Book with id: {bookId} does not exists", actual.Message);
        }
        #endregion
    }
}
