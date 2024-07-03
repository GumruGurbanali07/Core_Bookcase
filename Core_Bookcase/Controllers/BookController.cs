using Core_Bookcase.Data;
using Core_Bookcase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Bookcase.Controllers
{
	public class BookController : Controller
	{
		private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
			var items=_context.Books.ToList();
			return View(items);
		}
		[HttpGet]
		public IActionResult NewBook()
		{
			return View();
		}
		[HttpPost]
		public IActionResult NewBook(Book b)
		{
			_context.Books.Add(b);
			_context.SaveChanges();
			return RedirectToAction("Index");
			
		}
		public IActionResult DeleteBook(int id)
		{
			var res=_context.Books.Find(id);
			_context.Books.Remove(res);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}
		public IActionResult GetBook(int id)
		{
			var res = _context.Books.Find(id);
			return View("GetBook",res);
		}
		public IActionResult UpdateBook(Book b)
		{
			var bk = _context.Books.Find(b.Id);
            if (bk == null)
            {
                return NotFound();
            }
            bk.Name= b.Name;
			bk.Writer = b.Writer;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
