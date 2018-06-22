using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt3.Models;
using Projekt3.Repositories;

namespace Projekt3.Views
{
    public class AuthorsController : Controller
    {
        private readonly AuthorsRepository authorsRepository;

        public AuthorsController(AuthorsRepository authorsRepository)
        {
            this.authorsRepository = authorsRepository;
        }

        [Authorize(Roles = "user, admin")]
        // GET: Authors
        public ActionResult Index()
        {
            return View(authorsRepository.FindAll());
        }

        [Authorize(Roles = "user, admin")]
        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            return View(authorsRepository.FindById(id));
        }

        [Authorize(Roles = "admin")]
        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,LastName")] Author author)
        {
            if (ModelState.IsValid)
            {
                authorsRepository.Save(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        [Authorize(Roles = "admin")]
        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            return View(authorsRepository.FindById(id));
        }

        [Authorize(Roles = "admin")]
        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int authorId, [Bind("authorId,Name,LastName")] Author author)
        {
            if (ModelState.IsValid)
            {
                authorsRepository.Save(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        [Authorize(Roles = "admin")]
        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            return View(authorsRepository.FindById(id));
        }

        [Authorize(Roles = "admin")]
        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            authorsRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
