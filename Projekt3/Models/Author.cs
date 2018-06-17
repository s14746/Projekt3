using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt3.Models
{
    public class Author
    {
     
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
