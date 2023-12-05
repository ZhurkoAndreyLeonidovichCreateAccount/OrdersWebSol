using System.ComponentModel.DataAnnotations;

namespace OrdersWeb.BLL.Models
{
    public class OrderView
    {
        public int Id { get; set; }
        public string Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 


    }
}
