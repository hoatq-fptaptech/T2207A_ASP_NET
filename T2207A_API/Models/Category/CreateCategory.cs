using System;
using System.ComponentModel.DataAnnotations;
namespace T2207A_API.Models.Category
{
	public class CreateCategory
	{
		[Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
		[MinLength(3,ErrorMessage ="Nhập tối thiểu 3 ký tự")]
		[MaxLength(255,ErrorMessage ="Nhập tối đa 255 ký tự")]
		public string name { get; set; }
	}
}

