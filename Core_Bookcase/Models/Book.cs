using System.ComponentModel.DataAnnotations;

namespace Core_Bookcase.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Writer { get; set; }
        public int ReadId { get; set; }
        public Reader Reader { get; set; }
    }
}
