using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Data;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    // [Route("[controller]")]  // was default, but I'm not using this right now
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly ApplicationDbContext _db;

        public BookController(ILogger<BookController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objBookList = _db.Books.ToList();
            return View(objBookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (obj.Title == "SciFi")
            {
                ModelState.AddModelError("title", "Did you just enter a genre instead of a title?");
                return View();
            }
            else
            {
                _db.Books.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
        }

        public IActionResult Edit(int? bookId)
        {
            if (bookId == null || bookId == 0)
            {
                return NotFound();
            }
            Book bookFromDb = _db.Books.Find(bookId);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Book obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (obj.Title == "SciFi")
            {
                ModelState.AddModelError("title", "Did you just enter a genre instead of a title?");
                return View();
            }
            else
            {
                _db.Books.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}