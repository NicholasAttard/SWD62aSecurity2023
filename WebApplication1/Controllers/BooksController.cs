using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;
using System.Text.Encodings.Web;
using WebApplication1.Models;
using WebApplication1.Validators;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {

        BooksRepository _booksRepository;
        public BooksController(BooksRepository booksRepository) {
            _booksRepository = booksRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken()]
        [ServiceFilter(typeof(PermissionsActionFilter))]
        public IActionResult Create(BookViewModel book)
        { 
            if(ModelState.IsValid)
            {
                _booksRepository.Add(
                    new Domain.Models.Book()
                    {
                        Isbn = book.Isbn,
                        Name = HtmlEncoder.Default.Encode(book.Name),
                        Path = book.Path,
                        Year = book.Year
                    }

                    );

                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        
        }
    }
}
