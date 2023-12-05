using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrdersWeb.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace OrdersWeb.BLL.Models
{
    public class EditViewOrder
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [Display(Name = "Номер заказа")]
        public string Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Укажите провайдера")]
        [Range(1, int.MaxValue, ErrorMessage = "Укажите провайдера")]
        public int ProviderId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ProvidersNameList { get; set; }

        public List<OrderItem> Items { get; set; } = new();
    }
}
