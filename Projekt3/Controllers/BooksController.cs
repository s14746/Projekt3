using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt3.Data;
using Projekt3.Helpers;
using Projekt3.Models;
using Projekt3.Repositories;

namespace Projekt3.Views
{
    public class BooksController : Controller
    {
        private readonly BooksRepository booksRepository;
        private readonly AuthorsRepository authorsRepository;
        private readonly AuthorsHelper authorsHelper;

        public BooksController(
            BooksRepository booksRepository,
            AuthorsRepository authorsRepository,
            AuthorsHelper authorsHelper)
        {
            this.booksRepository = booksRepository;
            this.authorsHelper = authorsHelper;
            this.authorsRepository = authorsRepository;
        }

        [Authorize(Roles = "user, admin")]
        // GET: Books
        public ActionResult Index()
        {
            return View(booksRepository.FindAll());
        }

        [Authorize(Roles = "user, admin")]
        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View(booksRepository.FindById(id));
        }

        [Authorize(Roles = "admin")]
        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = authorsHelper.ToSelectList(authorsRepository.FindAll());
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Title,Publisher,PublicationDate,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                booksRepository.Save(book);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AuthorId = authorsHelper.ToSelectList(authorsRepository.FindAll());
            return View(book);
        }

        [Authorize(Roles = "admin")]
        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            var book = booksRepository.FindById(id);
            ViewBag.AuthorId = authorsHelper.ToSelectList(authorsRepository.FindAll(), book.Author.authorId);
            return View(book);
        }

        [Authorize(Roles = "admin")]
        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int bookId, [Bind("bookId,Title,Publisher,PublicationDate,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                booksRepository.Save(book);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AuthorId = authorsHelper.ToSelectList(authorsRepository.FindAll());
            return View(book);
        }

        [Authorize(Roles = "admin")]
        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View(booksRepository.FindById(id));
        }

        [Authorize(Roles = "admin")]
        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booksRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
