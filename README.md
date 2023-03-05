## Book API Assignment

### Assignment Step Description

In this Case study: BookAPI, we will create a RESTful application.
Representational State Transfer (REST) is an architectural style that specifies constraints.
In the REST architectural style, data and functionality are considered resources and are accessed using Uniform Resource Identifiers (URIs), typically links on the Web.

Resources are manipulated using a fixed set of four create, read, update, delete operations: GET, POST, PUT and DELETE.

- POST creates a new resource.
- GET retrieves the current state of a resource in some representation.
- PUT transfers a new state onto a resource.
- DELETE deletes a resource.

### Problem Statement

In this case study, we will develop a RESTful application with which we will manage books information.

### Following are the broad tasks

```
Create a new Book
Retreive all Books
Retreive Book based on BookId
Update Book based on BookId
Delete Book based on BookId
```

### API should have following endpoints

```
GET - /api/book - Should retreive all books
GET - /api/book/<bookid> - Should retreive book based on bookId
POST - /api/book - Should create new book
PUT - /api/book/<bookid> - Should update existing book based on bookId
DELETE - /api/book/<bookid> - Should delete existing book based on bookId
```

### Steps to be followed

```
Step 1: Define the data model class - Book.
Step 2: Define the entity in DataContext.
Step 3: Implement all methods in BookRepository.
Step 4: Implement all methods in BookService.
Step 5: Add code in controller methods to work with RESTful web services.
Step 6: Resolve DbContext options and all the dependencies in Startup.cs file
Step 6: Run all test cases to verify the correct functionality of Repository, Services & Controller.
```