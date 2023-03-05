using cgi_tollgate_assignment_book_api;
using cgi_tollgate_assignment_book_api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace test.Controller
{
    [Collection("Db collection")]
    [TestCaseOrderer("test.PriorityOrderer", "test")]
    public class BookControllerTest
    {
        private readonly HttpClient _client;
        public BookControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        #region Positive Tests
        [Fact, TestPriority(1)]
        public async Task AddBookShouldSuccess()
        {
            Book book = new Book { BookName = "Let us C", AuthorName = "Yashwant Kanitker", Genre = "Computer Programming", Price = 650 };
            HttpRequestMessage request = new HttpRequestMessage();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            // The endpoint or route of the controller action.
            var httpResponse = await _client.PostAsync<Book>("/api/book", book, formatter);
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Book>(stringResponse);
            Assert.Equal(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsAssignableFrom<Book>(response);
        }

        [Fact, TestPriority(2)]
        public async Task GetBookByIdShouldSuccess()
        {
            // The endpoint or route of the controller action.
            int bookId = 1;
            var httpResponse = await _client.GetAsync($"/api/book/{bookId}");
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<Book>(stringResponse);
            Assert.Equal("Master C Sharp", book.BookName);
        }

        [Fact, TestPriority(3)]
        public async Task GetAllBooksShouldSuccess()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/book");
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(stringResponse);
            Assert.Contains(books, c => c.BookName == "Let us C");
        }

        [Fact, TestPriority(4)]
        public async Task UpdateBookShouldSuccess()
        {
            int bookId = 1;
            Book book = new Book { BookName = "Let us C", AuthorName = "Yashwant Kanitker", Genre = "Computer Programming", Price = 550 };
            HttpRequestMessage request = new HttpRequestMessage();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            // The endpoint or route of the controller action.
            var httpResponse = await _client.PutAsync<Book>($"/api/book/{bookId}", book, formatter);
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.True(Convert.ToBoolean(stringResponse));
        }

        [Fact, TestPriority(5)]
        public async Task DeleteBookShouldSuccess()
        {
            int bookId = 2;
            // The endpoint or route of the controller action.
            var httpResponse = await _client.DeleteAsync($"/api/book/{bookId}");
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.True(Convert.ToBoolean(stringResponse));
        }
        #endregion
        #region Negative Tests
        [Fact, TestPriority(6)]
        public async Task GetBookByIdShouldReturnNotFound()
        {
            // The endpoint or route of the controller action.
            int bookId = 3;
            var httpResponse = await _client.GetAsync($"/api/book/{bookId}");
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
            Assert.Equal($"Book with id: {bookId} does not exists", stringResponse);
        }

        [Fact, TestPriority(7)]
        public async Task UpdateBookShouldFail()
        {
            int bookId = 3;
            Book book = new Book { BookName = "Let us C", AuthorName = "Yashwant Kanitker", Genre = "Computer Programming", Price = 650 };
            HttpRequestMessage request = new HttpRequestMessage();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            // The endpoint or route of the controller action.
            var httpResponse = await _client.PutAsync<Book>($"/api/book/{bookId}", book, formatter);
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
            Assert.Equal($"Book with id: {bookId} does not exists", stringResponse);
        }

        [Fact, TestPriority(8)]
        public async Task DeleteBookShouldFail()
        {
            int bookId = 3;
            // The endpoint or route of the controller action.
            var httpResponse = await _client.DeleteAsync($"/api/book/{bookId}");
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
            Assert.Equal($"Book with id: {bookId} does not exists", stringResponse);
        }
        #endregion
    }
}
