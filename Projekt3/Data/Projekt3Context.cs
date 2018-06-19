using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt3.Models;

namespace Projekt3.Models
{
    public class Projekt3Context : DbContext
    {
        public Projekt3Context (DbContextOptions<Projekt3Context> options)
            : base(options)
        {
        }

        public DbSet<Author> Author { get; set; }

        public DbSet<Book> Book { get; set; }
    }
}
