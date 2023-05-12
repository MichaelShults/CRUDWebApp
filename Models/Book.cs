using System.Xml.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWebApp.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public Genre Genre { get; set; }
        public string? Description { get; set; }
        public Author Author { get; set; } = new Author();
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        
        
    }

 
}
