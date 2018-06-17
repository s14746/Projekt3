using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt3.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }

        // Foreign key for Author
        public string AuthorID { get; set; }
        public Author Author { get; set; }
        public string Publisher { get; set; }
        public int PublicationDate { get; set; }


    }
}
