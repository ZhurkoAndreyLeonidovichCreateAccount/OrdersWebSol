using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.DAL.Entity
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Количество")]
        [Range(1, int.MaxValue, ErrorMessage ="Число не может быть отрицателным")]
        public decimal Quantity { get; set; }

        public string Unit { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        [ValidateNever]
        public virtual Order Order { get; set; }
    }
}
