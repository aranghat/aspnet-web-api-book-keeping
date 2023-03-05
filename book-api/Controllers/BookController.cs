using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cgi_tollgate_assignment_book_api.Exceptions;
using cgi_tollgate_assignment_book_api.Models;
using cgi_tollgate_assignment_book_api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cgi_tollgate_assignment_book_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /*
     * BookService should  be injected through constructor injection. Please note that we should not create service
     * object using the new keyword
     */
        private readonly IBookService service;
        public BookController(IBookService _service)
        {
            
        }

        /*
         * Define a handler method which will get us all the books from database table.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the books found successfully. 
         * 2. 500(Internal Server Error) - If there is an error while retreiving data from database table.
         * This handler method should map to the URL "/api/book" using HTTP GET method
         */
        // GET: api/<BookController>

        [HttpGet]
        public IActionResult Get()
        {
            
        }

        /*
         * Define a handler method which will get us the book by a bookId.
         * 
         * This handler method should return any one of the status messages basis on
         * different situations: 1. 200(OK) - If the book found successfully. 
         * 2. 404(NOT FOUND) - If the book with specified bookId is not found.
         * This handler method should map to the URL "/api/book/{userId}" using HTTP GET method
         */
        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
        }

        /*
         * Define a handler method which will create a book by reading the
         * Serialized book object from request body and save the book in
         * books table in database.
         * This handler method should return any one of the status messages
         * basis on different situations: 1. 201(CREATED - In case of successful
         * creation of the book 2. 500(Internal Server Error) - In case of and error while creating book
         * 
         *  * This handler method should map to the URL "/api/book" using HTTP POST method
         */

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            
        }

        /*
         * Define a handler method which will update a specific book by reading the
         * Serialized object from request body and save the updated book details in
         * a books table in database handle BookNotFoundException as well. 
         * This handler method should return any one of the status messages basis on different situations:
         * 1. 200(OK) - If the book updated successfully. 
         * 2. 404(NOT FOUND) - If the book with specified bookId is not found.
         * This handler method should map to the URL "/api/book/{id}" using HTTP PUT
         * method.
         */
        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            
        }

        /* Define a handler method which will delete a book from a database.
        * 
        * This handler method should return any one of the status messages basis on
        * different situations: 1. 200(OK) - If the book deleted successfully from
        * database. 2. 404(NOT FOUND) - If the book with specified bookId is
        * not found. 
        * 
        * This handler method should map to the URL "/api/book/{id}" using HTTP Delete
        * method" where "id" should be replaced by a valid bookId.
        */
        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
        }
    }
}
