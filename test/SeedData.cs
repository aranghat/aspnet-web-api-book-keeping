using cgi_tollgate_assignment_book_api.DAL;
using cgi_tollgate_assignment_book_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    public static class SeedData
    {
        public static void PopulateTestData(BookDataContext context)
        {
            AddBooks(context);
        }

        private static void AddBooks(BookDataContext context)
        {
            context.Books.Add(new Book { BookName = "Master C Sharp", AuthorName = "Steve Philips", Genre = "Computer Programming", Price = 580 });
            context.SaveChanges();
        }

        public static void DeleteTestData(BookDataContext context)
        {
            context.Books.RemoveRange(context.Books.ToList());
        }
    }

}
