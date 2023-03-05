using cgi_tollgate_assignment_book_api.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace test
{
    public class DatabaseFixture : IDisposable
    {
        public BookDataContext context;

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<BookDataContext>()
                .UseInMemoryDatabase(databaseName: "BookDB")
                .Options;

            //Initializing DbContext with InMemory
            context = new BookDataContext(options);
            // Insert seed data into the database using one instance of the context
            SeedData.PopulateTestData(context);
        }
        public void Dispose()
        {
            context = null;
        }
    }

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

}
