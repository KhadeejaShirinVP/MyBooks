using BooksWeb.Data;
using BooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //public IActionResult Index()
        //{
        //    var bookList= _dbContext.Books.ToList();
        //    return View();
        //}

        public IActionResult Index()
        {
            IEnumerable<Book>bookList = _dbContext.Books;
            return View(bookList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (book.Title == book.Author.ToString())
            {
                ModelState.AddModelError("Title", "The Author can't exactly match the Title");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                TempData["Success"] = "Book Created Successfully!";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //Get
        public IActionResult Edit(int? bookId)
        {
            if(bookId == null || bookId == 0)
            {
                return NotFound();
            }
            var bookFromContext= _dbContext.Books.Find(bookId);
            //var bookFromContextFirst = _dbContext.Books.FirstOrDefault(b => b.Book_ID==bookId);
            //var bookFromContextSingle= _dbContext.Books.SingleOrDefault(b=>b.Book_ID==bookId);

            if(bookFromContext == null) 
            {
                return NotFound();
            }
            return View(bookFromContext);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if(book.Title==book.Author.ToString())
            {
                ModelState.AddModelError("Title", "The Author can't exactly match the Title");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Books.Update(book);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //Get
        public IActionResult Delete(int? bookId)
        {
            if (bookId == null || bookId == 0)
            {
                return NotFound();
            }
            var bookFromContext = _dbContext.Books.Find(bookId);
            //var bookFromContext = _dbContext.Books.FirstOrDefault(b => b.Book_ID==bookId);
            //var bookFromContext= _dbContext.Books.SingleOrDefault(b=>b.Book_ID==bookId);

            if (bookFromContext == null)
            {
                return NotFound();
            }
            return View(bookFromContext);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            if(book == null)
            {
                return NotFound();
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
