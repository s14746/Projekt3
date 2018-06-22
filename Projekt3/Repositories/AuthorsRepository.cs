using Projekt3.Data;
using Projekt3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Projekt3.Repositories
{
    public class AuthorsRepository
    {
        private readonly ApplicationDbContext context;

        public AuthorsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Author> FindAll()
        {
            return context.Author.ToList();
        }

        public Author FindById(int id)
        {
            return context.Author.Find(id);
        }

        public void Save(Author author)
        {
            context.Update(author);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = context.Author.Find(id);
            context.Author.Remove(author);
            context.SaveChanges();
        }
    }
}
