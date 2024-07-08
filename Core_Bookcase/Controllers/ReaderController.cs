using Core_Bookcase.Data;
using Core_Bookcase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Core_Bookcase.Controllers
{
    public class ReaderController : Controller
    {
        private readonly AppDbContext _context;
        public ReaderController(AppDbContext context)
        {
            _context=context;

        }
        public IActionResult Index()
        {
            var veri=_context.Readers.Include(x=>x.Books).ToList();
            return View(veri);
        }
        [HttpGet]
        public IActionResult NewReader()
        {
            List<SelectListItem> items = (from x in _context.Books.ToList()
                                          select new SelectListItem
                                          {
                                              Text= x.Name,
                                              Value=x.Id.ToString(),
                                          }).ToList();
            ViewBag.BookItems=items;
            return View();
        }
        [HttpPost]
        public IActionResult NewReader(Reader reader, List<int> selectedBookIds)
        {
            if (selectedBookIds != null)
            {
                reader.Books = new List<Book>();
                foreach (var bookId in selectedBookIds)
                {
                    var book = _context.Books.Find(bookId);
                    if (book != null)
                    {
                        reader.Books.Add(book);
                    }
                }
            }

            _context.Readers.Add(reader);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
