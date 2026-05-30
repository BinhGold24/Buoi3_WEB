using System.ComponentModel.DataAnnotations;

namespace Bai6Validation.Models
{
    public class Book
    {
        public int Id { get; set; }

        // Kiểm tra điều kiện: Tên rỗng -> Báo lỗi "Không được để trống"
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }

        // Kiểm tra điều kiện: Giá <= 0 -> Báo lỗi "Giá phải lớn hơn 0"
        // Sử dụng khoảng từ 0.01 đến giá trị lớn nhất của kiểu double
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public double Price { get; set; }
    }
}