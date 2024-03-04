using Microsoft.AspNetCore.Mvc;
using WebBookStore.Models;

namespace WebBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var books = _bookRepository.GetAll();
            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(Book book)
        {
            if(ModelState.IsValid)
            {
                _bookRepository.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Detail(int id)
        {
            var book = _bookRepository.GetById(id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult Update(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]

        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            if( book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            _bookRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
