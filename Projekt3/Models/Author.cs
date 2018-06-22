using System.ComponentModel.DataAnnotations;

namespace Projekt3.Models
{
    public class Author
    {
        public int authorId { get; set; }

        [Required(ErrorMessage = "Name is required"), RegularExpression("^[A-Z][a-ząćśńółę]{2,}$", ErrorMessage = "Only letters are allowed, min. 2 characters .")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last name is required"), Display(Name = "Last name"),RegularExpression("^[A-Z][a-ząćśńółę]{2,}$", ErrorMessage = "Only letters are allowed, min. 2 characters")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", Name, LastName);
            }
        }
    }
}
