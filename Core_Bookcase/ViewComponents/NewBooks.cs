using Core_Bookcase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Bookcase.ViewComponents
{
    public class NewBooks:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var booklist = new List<Book>()
            {
                new Book
                {
                    Id=4,
                    Name="Book4",
                    Writer="Jesus4"
                }
            };
            return View(booklist);
        }
    }
}
