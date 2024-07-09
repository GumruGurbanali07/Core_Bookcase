using System.ComponentModel.DataAnnotations;

namespace Core_Bookcase.Models
{
	public class Admin
	{
		[Key]
		public int AdminId {  get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
