using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt3.Data;
using Projekt3.Models;

namespace Projekt3.Views
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _context.Book.Include(b => b.Author);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = _context.Book.Include(b => b.Author).Where(b => b.bookId == id).First();

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_context.Author.ToList(), "authorId", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Title,Publisher,PublicationDate,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AuthorId = new SelectList(_context.Author.ToList(), "authorId", "Name");
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = _context.Book.Include(b => b.Author).Where(b => b.bookId == id).First();
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.AuthorId = new SelectList(_context.Author.ToList(), "authorId", "Name", book.Author.authorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int bookId, [Bind("bookId,Title,Publisher,PublicationDate,AuthorId")] Book book)
        {
            if (bookId != book.bookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.bookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AuthorId = new SelectList(_context.Author.ToList(), "authorId", "Name");
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Book.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var book = _context.Book.Find(id);
            _context.Book.Remove(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.bookId == id);
        }
    }
}
