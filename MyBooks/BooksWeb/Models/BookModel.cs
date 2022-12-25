using System.ComponentModel.DataAnnotations;

namespace BooksWeb.Models
{
    public class BookModel
    {
        [Key]
        public int Book_ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Should be greater than or equal to 1")]
        public int price { get; set; }
    }
}
