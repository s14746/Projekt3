using Microsoft.EntityFrameworkCore;
using Projekt3.Data;
using Projekt3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Projekt3.Repositories
{
    public class BooksRepository
    {
        private readonly ApplicationDbContext context;

        public BooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Book> FindAll()
        {
            return context.Book.Include(b => b.Author).ToList();
        }

        public Book FindById(int id)
        {
            return context.Book.Include(b => b.Author).Where(b => b.bookId == id).First();
        }

        public void Save(Book book)
        {
            context.Update(book);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = FindById(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }
    }
}
