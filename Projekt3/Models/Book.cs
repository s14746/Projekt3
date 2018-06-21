namespace Projekt3.Models
{
    public class Book
    {
        public int bookId { get; set; }
        public string Title { get; set; }

        public string Publisher { get; set; }
        public int PublicationDate { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
