using Microsoft.AspNetCore.Mvc;
using Buoi5.Models;

namespace Buoi5.Controllers
{
    public class BookController : Controller
    {
        // Danh sách tĩnh để lưu trữ dữ liệu tạm thời trong bộ nhớ
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        // Chức năng 1: Danh sách sách
        // URL: /Book hoặc /Book/Index
        public IActionResult Index()
        {
            return View(_books);
        }

        // Chức năng 2: Chi tiết sách
        // URL: /Book/Detail/{id}
        public IActionResult Detail(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound("Không tìm thấy cuốn sách này!");
            }

            return View(book);
        }

        // Chức năng 3: Thêm sách (GET - Hiển thị Form)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Chức năng 3: Thêm sách (POST - Xử lý dữ liệu khi Submit)
        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            // Tự động tăng Id dựa trên Id lớn nhất hiện tại
            int newId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            newBook.Id = newId;

            _books.Add(newBook);

            // Gửi thông báo thành công sang View
            ViewBag.Message = "Thêm sách thành công!";

            return View();
        }
    }
}