using Microsoft.AspNetCore.Mvc;
using Bookshelf.Models;

namespace Bookshelf.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private static List<Book> books_on_my_shelf = new List<Book>
        {
            new Book { Id = 1, Title = "Small Island", Author = "Andrea Levy", Pages = 544, IsRead = true },
            new Book { Id = 2, Title = "Here Comes the Sun", Author = "Nicole Dennis-Benn", Pages = 352, IsRead = false },
            new Book { Id = 3, Title = "Things Fall Apart", Author = "Chinua Achebe", Pages = 209, IsRead = true },
            new Book { Id = 4, Title = "Purple Hibiscus", Author = "Chimamanda Ngozi Adichie", Pages = 307, IsRead = true },
            new Book { Id = 5, Title = "The Book of Night Women", Author = "Marlon James", Pages = 417, IsRead = true },
            new Book { Id = 6, Title = "Jane Eyre", Author = "Charlotte Bronte", Pages = 500, IsRead = false }
        };

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(books_on_my_shelf);
        }

        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            var book = books_on_my_shelf.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            ViewBag.LastId = books_on_my_shelf.Count;

            return View(book);
        }

        [HttpGet("{id:int}/mark-read")]
        public IActionResult MarkRead(int id)
        {
            var book = books_on_my_shelf.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            book.IsRead = true;

            TempData["Message"] = $"Marked {book.Title} as read";

            return RedirectToAction(nameof(Index));
        }
    }
}
