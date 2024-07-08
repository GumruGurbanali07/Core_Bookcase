using System.ComponentModel.DataAnnotations;

namespace Core_Bookcase.Models
{
    public class Reader
    {
        [Key]
        public int ReadId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> Books { get; set; }
      

    }
}
