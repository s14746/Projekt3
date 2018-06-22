using System.ComponentModel.DataAnnotations;

namespace Projekt3.Models
{
    public class Book
    {
        public int bookId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Publication date is required"), Display(Name = "Publication Date"), RegularExpression("^[0-9]{4}", ErrorMessage = "Please provide the correct year of publication in format yyyy")]
        public int PublicationDate { get; set; }

        
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
