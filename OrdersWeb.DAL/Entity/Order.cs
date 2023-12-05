using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersWeb.DAL.Entity
{
    public class Order
    {
        public int Id { get; set; }
        [Required]      
        [MinLength(5)]
        public string Number { get; set; }

       
        public DateTime Date { get; set; } 
        public int ProviderId { get; set; }

        [ForeignKey("ProviderId")]      
        public  Provider Provider { get; set; }
        //public virtual ICollection<OrderItem> Items { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}
