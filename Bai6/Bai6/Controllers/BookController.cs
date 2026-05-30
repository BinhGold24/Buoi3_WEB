using Microsoft.AspNetCore.Mvc;
using Bai6Validation.Models;

namespace Bai6Validation.Controllers
{
    public class BookController : Controller
    {
        // Danh sách tĩnh lưu trữ dữ liệu tạm thời trong bộ nhớ của bài 6
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 }
        };

        // Trang hiển thị danh sách sách hiện tại
        // URL: /Book hoặc /Book/Index
        public IActionResult Index()
        {
            return View(_books);
        }

        // GET: /Book/Create
        // Hiển thị Form để người dùng điền thông tin
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        // Xử lý dữ liệu nhận từ Form gửi lên
        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            // KIẾN THỨC TRỌNG TÂM: ModelState.IsValid
            // Tự động đối chiếu dữ liệu Form với các ràng buộc đặt tại Model ([Required], [Range])
            if (ModelState.IsValid)
            {
                // NẾU HỢP LỆ: Tiến hành thêm sách mới vào danh sách
                int newId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
                newBook.Id = newId;
                _books.Add(newBook);

                // Gửi thông báo thành công ra màn hình
                ViewBag.Message = "Thêm sách thành công!";

                // Trả về một đối tượng sách rỗng để làm sạch các ô nhập trên Form
                return View(new Book());
            }

            // NẾU KHÔNG HỢP LỆ (Dữ liệu lỗi):
            // Trả lại chính View đó cùng với đối tượng 'newBook' chứa các lỗi nhập liệu.
            // ASP.NET Core sẽ tự giữ lại dữ liệu cũ người dùng đã nhập và hiển thị câu thông báo lỗi đỏ.
            return View(newBook);
        }
    }
}