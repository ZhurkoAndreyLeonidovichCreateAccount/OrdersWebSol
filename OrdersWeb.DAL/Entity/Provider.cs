using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.DAL.Entity
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<Order> Orders { get; set; }
    }
}
