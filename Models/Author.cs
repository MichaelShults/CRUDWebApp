using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWebApp.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books = new List<Book>();
        [Display(Name = "Author Description")]
        public string? AuthorDescription { get; set; }

    }
}
